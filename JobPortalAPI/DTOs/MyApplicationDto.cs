namespace JobPortalAPI.DTOs
{
    public class MyApplicationDto
    {
        public int ApplicationId { get; set; }

        public string JobTitle { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime AppliedDate { get; set; }
    }
}

