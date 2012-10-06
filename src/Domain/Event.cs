using System;

namespace Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime Start { get; private set; }
        public virtual Location Location { get; private set; }
        public string Website { get; private set; }



        public static Event Create(string title, DateTime start)
        {
            var ev = new Event();
            ev.Update(title, start);
            return ev;
        }

        public void Update(string title, DateTime start, string description = "", string website ="")
        {
            Title = title;
            Start = start;
            Description = description;
            Website = website;

        }

        public void SetLocation(Location location)
        {
            Location = location;
        }
    }
}