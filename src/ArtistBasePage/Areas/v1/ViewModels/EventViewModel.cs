using System;

namespace ArtistBasePage.Areas.v1.ViewModels
{
    public class EventViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public EventOrigin Source { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public string ShortDescription
        {
            get
            {
                return
                    Description.Length > 250
                        ? Description.Substring(0, 250) + " ..."
                        : Description;
            }
        }
    }
}