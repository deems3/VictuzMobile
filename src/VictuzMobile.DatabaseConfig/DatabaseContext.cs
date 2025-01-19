using DatabaseConfig.Models;
using Microsoft.EntityFrameworkCore;
using VictuzMobile.DatabaseConfig.Models;

namespace VictuzMobile.DatabaseConfig
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Models.Location> Locations { get; set; } = null!;
        public DbSet<Registration> Registrations { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Suggestion> Suggestions { get; set; } = null!;

        // Constructor with no argument is required and it is used when adding/removing migrations from class library
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        // It is required to override this method when adding/removing migrations from class library
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite();
    }
}
