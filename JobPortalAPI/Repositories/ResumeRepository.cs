using JobPortalAPI.Data;
using JobPortalAPI.DTOs;
using JobPortalAPI.Models;

namespace JobPortalAPI.Repositories
{
    public class ResumeRepository : IResumeRepository
    {
        private readonly AppDbContext _context;

        public ResumeRepository(AppDbContext context)
        {
            _context = context;
        }

        public Resume? GetResumeByUserId(int userId)
        {
            var all = _context.Resumes.ToList();

            return _context.Resumes
                .FirstOrDefault(r => r.UserId == userId);
        }

        public Resume? GetResumeById(int id)
        {
            return _context.Resumes.FirstOrDefault(x => x.Id == id);
        }

        public void RemoveResume(Resume resume)
        {
            _context.Resumes.Remove(resume);
        }
    }
}
