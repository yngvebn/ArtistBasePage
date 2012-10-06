namespace Domain
{
    public class Location
    {
        public int Id { get; set; }
        public virtual GeoLocation GeoPoint { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string Address { get; private set; }

        public static Location Create(string city, string address, string country)
        {
            var location = new Location();
            location.Update(city, address, country);
            return location;
        }

        public void Update(string city, string address, string country)
        {
            Address = address;
            City = city;
            Country = country;

        }

        public void SetGeoLocation(GeoLocation location)
        {
            GeoPoint = location;
        }
    }

    public class GeoLocation
    {
        public int Id { get; set; }
        public double GeoLat { get; private set; }
        public double GeoLong { get; private set; }

        public void Update(double geoLat, double geoLong)
        {
            GeoLat = geoLat;
            GeoLong = geoLong;
        }

        public static GeoLocation Create(double geoLat, double geoLong)
        {
            GeoLocation geo = new GeoLocation();
            geo.Update(geoLat, geoLong);
            return geo;
        }
    }
}