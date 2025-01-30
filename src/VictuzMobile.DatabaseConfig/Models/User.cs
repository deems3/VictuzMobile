using DatabaseConfig.Models;

namespace VictuzMobile.DatabaseConfig.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public int StudentNumber { get; set; }
        public string? ProfileImage { get; set; } = null!;
        public ICollection<Registration> Registrations { get; set; } = [];
        public bool Limited { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public ICollection<Suggestion> LikedSuggestions { get; set; } = [];
    }

    public enum UserRole
    {
        Admin,
        User
    }
}
