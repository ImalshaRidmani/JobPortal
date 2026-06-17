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

        public JobApplication? GetApplication(int jobId, int userId)
        {
            return _context.JobApplications
                .FirstOrDefault(x => x.JobId == jobId && x.UserId == userId);
        }

        public void AddApplication(JobApplication application)
        {
            _context.JobApplications.Add(application);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void AddJob(Job job)
        {
            _context.Jobs.Add(job);
        }
    }
}
