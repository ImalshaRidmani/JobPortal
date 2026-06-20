using JobPortalAPI.Data;
using JobPortalAPI.DTOs;
using JobPortalAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobPortalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ResumeController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost("upload")]
        [Authorize]
        public async Task<IActionResult> UploadResume([FromForm] UploadResumeDto request)
        {
            var userIdClaim =
                User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim);

            if (request.File == null || request.File.Length == 0)
                return BadRequest("No file uploaded");

            // Only allow PDF
            var extension = Path.GetExtension(request.File.FileName);
            if (extension != ".pdf")
                return BadRequest("Only PDF files allowed");

            var fileName = Guid.NewGuid().ToString() + extension;
            var path = Path.Combine(_env.WebRootPath, "resumes", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await request.File.CopyToAsync(stream);
            }

            var resume = new Resume
            {
                UserId = userId,
                FileName = request.File.FileName,
                FilePath = "/resumes/" + fileName
            };

            _context.Resumes.Add(resume);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Resume uploaded successfully",
                filePath = resume.FilePath
            });
        }
    }
}
