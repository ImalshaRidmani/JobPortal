using JobPortalAPI.DTOs;
using JobPortalAPI.Models;

namespace JobPortalAPI.Services
{
    public interface IResumeService
    {
        Resume? GetMyResume(int userId);
    }
}
