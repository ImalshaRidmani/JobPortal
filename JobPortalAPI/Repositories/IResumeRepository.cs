using JobPortalAPI.DTOs;
using JobPortalAPI.Models;

namespace JobPortalAPI.Repositories
{
    public interface IResumeRepository
    {
        Resume? GetResumeByUserId(int userId);
    }
}
