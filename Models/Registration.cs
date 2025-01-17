using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictuzMobile.Abstractions;

namespace VictuzMobile.Models
{
    public class Registration
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int ActivityId { get; set; }
        public Activity Activity { get; set; } = null!;
    }
}
