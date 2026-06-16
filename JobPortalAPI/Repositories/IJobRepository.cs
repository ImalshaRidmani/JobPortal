using JobPortalAPI.Models;

namespace JobPortalAPI.Repositories
{
    public interface IJobRepository
    {
        List<Job> GetAllJobs();
    }
}
