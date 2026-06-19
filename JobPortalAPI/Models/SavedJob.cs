namespace JobPortalAPI.Models
{
    public class SavedJob
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int JobId { get; set; }

        public User User { get; set; } = null;

        public Job Job { get; set; } = null;
    }
}
