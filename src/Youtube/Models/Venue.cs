namespace Youtube.Models
{
    public class Venue
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}