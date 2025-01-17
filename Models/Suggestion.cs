using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictuzMobile.Models
{
    public class Suggestion : Activity
    {
        public ICollection<User> Likes { get; set; } = [];
    }
}
