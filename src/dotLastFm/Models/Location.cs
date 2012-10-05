using RestSharp.Deserializers;

namespace DotLastFm.Models
{
    public class Location
    {
        [DeserializeAs(Name = "point")]
        public GeoLocation GeoPoint { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
    }
}