namespace VictuzMobile.DatabaseConfig.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Street { get; set; } = null!;
        public string Housenumber { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
