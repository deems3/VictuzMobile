using VictuzMobile.DatabaseConfig.Models;
using Location = VictuzMobile.DatabaseConfig.Models.Location;

namespace DatabaseConfig.Models
{
    public class Suggestion
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int MaxRegistrations { get; set; }
        public string ImageURL { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int OrganiserId { get; set; }
        public User Organiser { get; set; } = null!;

        public ICollection<Registration> Registration { get; set; } = [];

        public int LocationId { get; set; }
        public Location Location { get; set; } = null!;

        public ICollection<User> LikedByUsers { get; set; } = new List<User>();
    }
}
