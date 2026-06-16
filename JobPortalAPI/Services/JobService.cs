using JobPortalAPI.Data;
using JobPortalAPI.Models;

namespace JobPortalAPI.Services
{
    public class JobService : IJobService
    {
        private readonly AppDbContext _context;

        public JobService(AppDbContext context)
        {
            _context = context;
        }

        public List<Job> GetAllJobs()
        {
            return _context.Jobs.ToList();
        }
    }
}
