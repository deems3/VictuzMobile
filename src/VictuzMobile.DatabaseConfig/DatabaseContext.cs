using DatabaseConfig.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
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

        // Define the culture for DateTime parsing, this prevents the need for creating a new migration when someone has a different language installed on their computer.
        private readonly CultureInfo culture = CultureInfo.CreateSpecificCulture("nl-NL");

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique(); // Ensure that the username is unique

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "demi", DisplayName = "Demi", Email = "demi@example.com", PhoneNumber = "123456789", StudentNumber = 1234567, PasswordHash = "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq" },
                new User { Id = 2, Username = "mees", DisplayName = "Mees", Email = "mees@example.com", PhoneNumber = "123456789", StudentNumber = 2345678, PasswordHash = "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq" },
                new User { Id = 3, Username = "bas", DisplayName = "Bas", Email = "bas@example.com", PhoneNumber = "123456789", StudentNumber = 3456789, PasswordHash = "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq" },
                new User { Id = 4, Username = "finn", DisplayName = "Finn", Email = "finn@example.com", PhoneNumber = "123456789", StudentNumber = 4567890, PasswordHash = "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq" },
                new User { Id = 5, Username = "user", DisplayName = "User", Email = "user@example.com", PhoneNumber = "123456789", StudentNumber = 8971627, PasswordHash = "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq" },
                new User { Id = 6, Username = "admin", DisplayName = "Admin", Email = "admin@example.com", PhoneNumber = "123456789", StudentNumber = 7176123, PasswordHash = "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq", Role = UserRole.Admin }
            );


            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Sport" },
                new Category { Id = 2, Name = "AI" },
                new Category { Id = 3, Name = "Workshop" },
                new Category { Id = 4, Name = "Programmeren" }
            );

            modelBuilder.Entity<Models.Location>().HasData(
                new Models.Location { Id = 1, Street = "Nieuw Eyckholt", Housenumber = "300", PostalCode ="6419 DJ", City = "Heerlen", Province = "Limburg", Country = "Nederland"}
            );

            modelBuilder.Entity<Activity>().HasData(
                new Activity { Id = 1, CategoryId = 1, Name = "Voetbal Toernooi", Description = "Kom voetballen", LocationId = 1, StartDate = DateTime.Parse("01-04-2026", culture), EndDate = DateTime.Parse("01-04-2026", culture), OrganiserId = 2, MaxRegistrations = 22, ImageURL = "https://cdn.pixabay.com/photo/2014/10/14/20/24/ball-488718_640.jpg" },
                new Activity { Id = 2, CategoryId = 2, Name = "Omgaan met AI", Description = "Leer hoe jij je eigen AI kunt maken", LocationId = 1, StartDate = DateTime.Parse("03-04-2026", culture), EndDate = DateTime.Parse("03-04-2026", culture), OrganiserId = 1, MaxRegistrations = 6, ImageURL = "https://img.freepik.com/free-photo/ai-human-technology-background_1409-5588.jpg" },
                new Activity { Id = 3, CategoryId = 3, Name = "Kleien", Description = "Klei je eigen technische tool", LocationId = 1, StartDate = DateTime.Parse("03-05-2026", culture), EndDate = DateTime.Parse("03-05-2026", culture), OrganiserId = 3, MaxRegistrations = 10, ImageURL = "https://cdn.pixabay.com/photo/2016/03/27/17/10/pottery-1283146_1280.jpg" }
            );

            // Manually define relationship with the Users table
            modelBuilder.Entity<Suggestion>()
                 .HasOne(s => s.Organiser)
                 .WithMany()
                 .HasForeignKey(s => s.OrganiserId);

            // Explicitly define many to many relationship
            modelBuilder.Entity<Suggestion>()
                .HasMany(s => s.LikedByUsers)
                .WithMany(u => u.LikedSuggestions)
                .UsingEntity(j => j.ToTable("SuggestionLikes"));

            modelBuilder.Entity<Suggestion>().HasData(
                new Suggestion { Id = 1, CategoryId = 3, Name = "Cybersecurity", Description = "Leer hoe jij je eigen netwerk kunt beveiligen", LocationId = 1, StartDate = DateTime.Parse("01-03-2026", culture), EndDate = DateTime.Parse("01-03-2026", culture), OrganiserId = 2, MaxRegistrations = 10, ImageURL = "cybersecurity.jpg" },
                new Suggestion { Id = 2, CategoryId = 4 , Name = "Robots programmeren", Description = "Programmeer je eigen robot", LocationId = 1, StartDate = DateTime.Parse("03-03-2026", culture), EndDate = DateTime.Parse("03-03-2026", culture), OrganiserId = 1, MaxRegistrations = 6, ImageURL = "robot_suggestion.jpg" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
