using JobPortalAPI.DTOs;
using JobPortalAPI.Models;

namespace JobPortalAPI.Repositories
{
    public interface IResumeRepository
    {
        Resume? GetResumeByUserId(int userId);

        Resume? GetResumeById(int id);

        void RemoveResume(Resume resume);
    }
}
