using JobPortalAPI.Models;

namespace JobPortalAPI.Services
{
    public interface IJobService
    {
        List<Job> GetAllJobs();
    }
}
