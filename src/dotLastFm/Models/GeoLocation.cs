using RestSharp.Deserializers;

namespace DotLastFm.Models
{
    public class GeoLocation
    {
        [DeserializeAs(Name = "lat")]
        public double GeoLat { get; set; }
        [DeserializeAs(Name = "long")]
        public double GeoLong { get; set; }
    }
}