using VictuzMobile.DatabaseConfig;
using VictuzMobile.DatabaseConfig.Models;

namespace VictuzMobile.App.Services
{
    public class AuthService(DatabaseContext context)
    {
        public User? Authenticate(string username, string password)
        {
            // Try to fetch a user from the database
            var user = context.Users.FirstOrDefault(u => u.Username == username);

            // User with given username does not exist, return null
            if (user == null)
            {
                return null;
            }

            // Verify the given password against the stored password hash for the user
            var passwordVerified = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            // If the password is correct, return the user, otherwise return null
            return passwordVerified ? user : null;
        }

        public async Task<User?> GetUser(int id)
        {
            return await context.Users.FindAsync(id);
        }
    }
}
