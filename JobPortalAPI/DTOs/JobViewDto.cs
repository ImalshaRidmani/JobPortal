namespace JobPortalAPI.DTOs
{
    public class JobViewDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public string CompanyName { get; set; } = string.Empty;

        public string? CompanyLogo { get; set; }
    }
}
