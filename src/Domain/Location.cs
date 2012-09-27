namespace Domain
{
    public class Location
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public long Latitude { get; private set; }
        public long Longitude { get; private set; }
    }
}