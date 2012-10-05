namespace DotLastFm.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public string Url { get; set; }
        public string WebSite { get; set; }
    }
}