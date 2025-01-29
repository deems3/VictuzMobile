namespace VictuzMobile.DatabaseConfig.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int ActivityId { get; set; }
        public Activity Activity { get; set; } = null!;

        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}
