using RestSharp.Deserializers;

namespace DotLastFm.Models
{
    public class EventWrapper
    {
        [DeserializeAs(Name = "event")]
        public ArtistEvent Events { get; set; }
    }
}