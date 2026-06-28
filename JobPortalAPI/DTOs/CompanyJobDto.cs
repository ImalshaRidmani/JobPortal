namespace JobPortalAPI.DTOs
{
    public class CompanyJobDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public DateTime PostedDate { get; set; }
    }
}
