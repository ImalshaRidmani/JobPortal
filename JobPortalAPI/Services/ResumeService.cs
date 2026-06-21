using JobPortalAPI.Data;
using JobPortalAPI.DTOs;
using JobPortalAPI.Models;
using JobPortalAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobPortalAPI.Services
{
    public class ResumeService : IResumeService
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ResumeService(IResumeRepository ResumeRepository, AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _resumeRepository = ResumeRepository;
            _env = env;
        }

        public Resume? GetMyResume(int userId)
        {
            return _resumeRepository.GetResumeByUserId(userId);
        }

        public async Task<string> DeleteResume(int id)
        {
            var resume = _resumeRepository.GetResumeById(id);

            if (resume == null)
                return "Resume not found";

            // delete file from server
            var fullPath = Path.Combine(_env.WebRootPath, resume.FilePath.TrimStart('/'));

            if (File.Exists(fullPath))
                File.Delete(fullPath);

            _resumeRepository.RemoveResume(resume);

            SaveChangesAsync();

            return "Resume deleted successfully";
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
