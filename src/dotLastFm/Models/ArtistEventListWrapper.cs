using RestSharp.Deserializers;

namespace DotLastFm.Models
{
    public class ArtistEventListWrapper
    {
        [DeserializeAs(Name = "events")]
        public EventWrapper Events { get; set; }

    }
}