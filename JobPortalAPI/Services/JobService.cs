using JobPortalAPI.Data;
using JobPortalAPI.DTOs;
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

        public async Task<Job> CreateJob(JobDto request, int employerId)
        {
            var job = new Job
            {
                Title = request.Title,
                Description = request.Description,
                Location = request.Location,
                Salary = request.Salary,
                EmployerId = employerId
            };

            _jobRepository.AddJob(job);

            await _jobRepository.SaveChangesAsync();

            return job;
        }

        public List<JobApplicationViewDto> GetMyApplications(int employerId)
        {
            return _jobRepository.GetApplicationForEmployer(employerId);
        }

        public async Task<string> AcceptApplication(int applicationId)
        {
            var application =
                _jobRepository.GetApplicationById(applicationId);

            if (application == null)
                return "Application not found";

            application.Status = "Accepted";

            await _jobRepository.SaveChangesAsync();

            return "Application accepted";
        }

        public async Task<string> RejectApplication(int applicationId)
        {
            var application =
                _jobRepository.GetApplicationById(applicationId);

            if (application == null)
                return "Application not found";

            application.Status = "Rejected";

            await _jobRepository.SaveChangesAsync();

            return "Application rejected";
        }
    }
}
