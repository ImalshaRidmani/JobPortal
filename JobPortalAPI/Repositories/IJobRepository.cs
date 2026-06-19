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

        JobApplication? GetApplicationById(int id);  

        List<JobApplicationViewDto> GetApplicationForEmployer(int employerId);

        List<MyApplicationDto> GetApplicationsByUserId(int userId);

        SavedJob? GetSavedJob(int UserId, int JobId);

        void AddSavedJob(SavedJob savedJob);

        Task SaveChangesAsync();

        List<Job> GetSavedJobs(int userId);
    }
}
