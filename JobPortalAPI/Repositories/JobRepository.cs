using JobPortalAPI.Data;
using JobPortalAPI.Models;

namespace JobPortalAPI.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Job> GetAllJobs()
        {
            return _context.Jobs.ToList();
        }
    }
}
