using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictuzMobile.Abstractions;

namespace VictuzMobile.Models
{
    public class Location : TableData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Street { get; set; } = null!;
        public string Housenumber { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
