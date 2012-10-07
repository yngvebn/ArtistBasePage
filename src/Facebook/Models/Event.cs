using System;

namespace Facebook.Models
{
    public class Event
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
        public string Location { get; set; }
        public Venue Venue { get; set; }
        public string Website { get; set; }
        public User Owner { get; set; }
 
    }
}