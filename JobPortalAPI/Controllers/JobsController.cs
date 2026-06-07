using JobPortalAPI.Data;
using JobPortalAPI.DTOs;
using JobPortalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobPortalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JobsController(AppDbContext context)
        {
            _context = context;
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
            var jobs = _context.Jobs.ToList();
            return Ok(jobs);
        }
    }
}
