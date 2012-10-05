using System;
using System.Collections.ObjectModel;

namespace DotLastFm.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public EventArtists Artists { get; set; }

        public Venue Venue { get; set; }

        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Website { get; set; }
 
    }
}