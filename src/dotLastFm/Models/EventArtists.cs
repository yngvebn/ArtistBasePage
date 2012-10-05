using System.Collections.Generic;
using RestSharp.Deserializers;

namespace DotLastFm.Models
{
    [DeserializeAs(Name = "artists")]
    public class EventArtists
    {
       
        public List<string> Artist { get; set; } 
        public string HeadLiner { get; set; }
    }
}