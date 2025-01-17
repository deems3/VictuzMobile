using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictuzMobile.Models
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
        public ICollection<Registration> Registrations { get; set; } = [];
        public bool Limited { get; set; }

    }
}
