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
    }
}
