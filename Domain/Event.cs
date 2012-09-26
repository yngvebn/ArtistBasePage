using System;

namespace Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public virtual Location Location { get; private set; }
    }
}