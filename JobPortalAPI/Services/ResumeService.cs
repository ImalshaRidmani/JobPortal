using JobPortalAPI.Data;
using JobPortalAPI.DTOs;
using JobPortalAPI.Models;
using JobPortalAPI.Repositories;

namespace JobPortalAPI.Services
{
    public class ResumeService : IResumeService
    {
        private readonly IResumeRepository _resumeRepository;
        //private readonly AppDbContext _context;

        public ResumeService(IResumeRepository ResumeRepository)
        {
            //_context = context;
            _resumeRepository = ResumeRepository;
        }

        public Resume? GetMyResume(int userId)
        {
            return _resumeRepository.GetResumeByUserId(userId);
        }
    }
}
