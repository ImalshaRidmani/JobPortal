using JobPortalAPI.DTOs;
using JobPortalAPI.Models;

namespace JobPortalAPI.Services
{
    public interface IJobService
    {
        List<Job> GetAllJobs();

        Task<string> ApplyJob(int jobId, int userId);

        Task<Job> CreateJob(JobDto request, int employerId);

        List<JobApplicationViewDto> GetMyApplicants(int employerId);

        Task<string> AcceptApplication(int applicationId);

        Task<string> RejectApplication(int applicationId);

        List<MyApplicationDto> GetMyApplications(int userId);

        Task<string> SaveJob(int userId, int jobId);

        List<Job> GetSavedJobs(int userId);

        Task<string> RemoveSavedJob(int id);
    }
}
