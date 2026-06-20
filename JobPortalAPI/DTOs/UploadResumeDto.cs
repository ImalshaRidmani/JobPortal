using Microsoft.AspNetCore.Http;

namespace JobPortalAPI.DTOs
{
    public class UploadResumeDto
    {
        public IFormFile File { get; set; } = null;
    }
}
