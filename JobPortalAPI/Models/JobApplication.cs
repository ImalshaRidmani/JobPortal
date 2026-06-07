namespace JobPortalAPI.Models
{
    public class JobApplication
    {
        public int Id { get; set; }

        public int JobId { get; set; }

        public int UserId { get; set; }

        public DateTime AppliedDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Applied";
    }
}
