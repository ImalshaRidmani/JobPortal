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
            var userIdClaim = User.FindFirst(
                System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var role = User.FindFirst(
                System.Security.Claims.ClaimTypes.Role)?.Value;

            if (userIdClaim == null)
                return Unauthorized();

            if (role != "Employer")
                return StatusCode(403, "Only Employers can create jobs");

            int employerId = int.Parse(userIdClaim);

            var job = await _jobService.CreateJob(request, employerId);

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

            var applications = _jobService.GetMyApplicants(employerId);

            return Ok(applications);
        }

        [HttpPut("applications/{id}/accept")]
        [Authorize]
        public async Task<IActionResult> AcceptApplication(int id)
        {
            var result = await _jobService.AcceptApplication(id);

            if (result == "Application not found")
                return NotFound(result);

            return Ok(result);
        }

        [HttpPut("applications/{id}/reject")]
        [Authorize]
        public async Task<IActionResult> RejectApplication(int id)
        {
            var result = await _jobService.RejectApplication(id);

            if (result == "Application not found")
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("my-applications")]
        [Authorize]
        public IActionResult GetMyApplications()
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim);

            var applications = _jobService.GetMyApplications(userId);

            return Ok(applications);
        }

        [HttpPost("save")]
        [Authorize]
        public async Task<IActionResult> SaveJob(SaveJobDto request)
        {
            var userIdClaim =
                User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim);

            var result =
                await _jobService.SaveJob(userId, request.JobId);

            if (result == "Job already saved")
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("saved")]
        [Authorize]
        public IActionResult GetSavedJobs()
        {
            var userIdClaim =
                User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim);

            var savedJobs = _jobService.GetSavedJobs(userId);

            return Ok(savedJobs);
        }
    }
}
