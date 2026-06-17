using JobPortalAPI.Data;
using JobPortalAPI.Models;
using JobPortalAPI.Repositories;

namespace JobPortalAPI.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        //private readonly AppDbContext _context;

        public JobService(IJobRepository jobRepository)
        {
            //_context = context;
            _jobRepository = jobRepository;
        }

        public List<Job> GetAllJobs()
        {
            //return _context.Jobs.ToList();
            return _jobRepository.GetAllJobs();
        }

        public async Task<string> ApplyJob(int jobId, int userId)
        {
            var alreadyApplied =
                _jobRepository.GetApplication(jobId, userId);

            if (alreadyApplied != null)
            {
                return "You already applied for this job";
            }

            var application = new JobApplication
            {
                JobId = jobId,
                UserId = userId,
                Status = "Applied"
            };

            _jobRepository.AddApplication(application);

            await _jobRepository.SaveChangesAsync();

            return "Job applied successfully";
        }
    }
}
