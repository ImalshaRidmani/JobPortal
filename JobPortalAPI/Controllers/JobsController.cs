using JobPortalAPI.Data;
using JobPortalAPI.DTOs;
using JobPortalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using JobPortalAPI.Services;

namespace JobPortalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IJobService _jobService;

        public JobsController(AppDbContext context, IJobService jobService)
        {
            _context = context;
            _jobService = jobService;
        }

        // CREATE JOB
        [HttpPost]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public async Task<IActionResult> CreateJob(JobDto request)
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var roleClaim = User.FindFirst(ClaimTypes.Role)?.Value;

            if (userIdClaim == null)
            {
                return Unauthorized("Invalid token");
            }

            // 🔐 ROLE CHECK HERE
            if (roleClaim != "Employer")
                return StatusCode(403, "Only Employers can create jobs");

            int employerId = int.Parse(userIdClaim);

            var job = new Job
            {
                Title = request.Title,
                Description = request.Description,
                Location = request.Location,
                Salary = request.Salary,
                EmployerId = employerId // temporary (we fix with JWT later)
            };

            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();

            return Ok(job);
        }
        [HttpGet]
        public IActionResult GetJobs()
        {
            var jobs = _jobService.GetAllJobs();

            return Ok(jobs);
        }

        [HttpPost("apply")]
        [Authorize]
        public async Task<IActionResult> ApplyJob(ApplyJobDto request)
        {
            var userIdClaim =
        User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim);

            var result =
                await _jobService.ApplyJob(request.JobId, userId);

            if (result == "You already applied for this job")
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("my-applicants")]
        [Authorize]
        public IActionResult GetMyApplicants()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            if (userIdClaim == null)
                return Unauthorized();

            if (role != "Employer")
                return StatusCode(403, "Only Employers can view applicants");

            int employerId = int.Parse(userIdClaim);

            var result = (from app in _context.JobApplications
                          join job in _context.Jobs on app.JobId equals job.Id
                          join user in _context.Users on app.UserId equals user.Id
                          where job.EmployerId == employerId
                          select new JobApplicationViewDto
                          {
                              ApplicationId = app.Id,
                              JobTitle = job.Title,
                              ApplicantEmail = user.email,
                              Status = app.Status,
                              AppliedDate = app.AppliedDate
                          }).ToList();

            return Ok(result);
        }

        [HttpPut("applications/{id}/accept")]
        [Authorize]
        public async Task<IActionResult> AcceptApplication(int id)
        {
            var application = await _context.JobApplications.FindAsync(id);

            if (application == null)
                return NotFound("Application not found");

            application.Status = "Accepted";

            await _context.SaveChangesAsync();

            return Ok("Application accepted");
        }

        [HttpPut("applications/{id}/reject")]
        [Authorize]
        public async Task<IActionResult> RejectApplication(int id)
        {
            var application = await _context.JobApplications.FindAsync(id);

            if (application == null)
                return NotFound("Application not found");

            application.Status = "Rejected";

            await _context.SaveChangesAsync();

            return Ok("Application rejected");
        }

        [HttpGet("my-applications")]
        [Authorize]
        public IActionResult GetMyApplications()
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim);

            var applications = (from app in _context.JobApplications
                                join job in _context.Jobs
                                on app.JobId equals job.Id
                                where app.UserId == userId
                                select new
                                {
                                    app.Id,
                                    JobTitle = job.Title,
                                    job.Location,
                                    app.Status,
                                    app.AppliedDate
                                }).ToList();

            return Ok(applications);
        }
    }
}
