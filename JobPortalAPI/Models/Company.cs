namespace JobPortalAPI.Models
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public string Website { get; set; } = string.Empty;

        public string? LogoPath { get; set; }

        public int EmployerId { get; set; }

        public User Employer { get; set; } = null!;
    }
}
