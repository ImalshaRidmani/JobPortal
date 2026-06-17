using JobPortalAPI.DTOs;
using JobPortalAPI.Models;

namespace JobPortalAPI.Services
{
    public interface IJobService
    {
        List<Job> GetAllJobs();

        Task<string> ApplyJob(int jobId, int userId);

        Task<Job> CreateJob(JobDto request, int employerId);

        List<JobApplicationViewDto> GetMyApplications(int employerId);

        Task<string> AcceptApplication(int applicationId);

        Task<string> RejectApplication(int applicationId);
    }
}
