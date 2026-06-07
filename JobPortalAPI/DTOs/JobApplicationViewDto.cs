namespace JobPortalAPI.DTOs
{
    public class JobApplicationViewDto
    {
        public int ApplicationId { get; set; }

        public string JobTitle { get; set; } = string.Empty;

        public string ApplicantEmail { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime AppliedDate { get; set; }
    }
}
