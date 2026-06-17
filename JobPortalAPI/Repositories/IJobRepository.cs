using JobPortalAPI.DTOs;
using JobPortalAPI.Models;

namespace JobPortalAPI.Repositories
{
    public interface IJobRepository
    {
        List<Job> GetAllJobs();

        JobApplication? GetApplication(int jobId, int userId);

        void AddApplication(JobApplication application);

        void AddJob(Job job);

        Task SaveChangesAsync();

        List<JobApplicationViewDto> GetApplicationForEmployer(int employerId);
    }
}
