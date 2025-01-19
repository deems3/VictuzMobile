using VictuzMobile.DatabaseConfig.Models;

namespace DatabaseConfig.Models
{
    public class Suggestion : Activity
    {
        public ICollection<User> Likes { get; set; } = [];
    }
}
