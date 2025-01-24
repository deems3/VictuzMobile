using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictuzMobile.DatabaseConfig.Helpers
{
    public static class AuthHelper
    {
        public static string GeneratePaswordHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
