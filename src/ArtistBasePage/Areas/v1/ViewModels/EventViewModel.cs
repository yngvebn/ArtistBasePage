using System;

namespace ArtistBasePage.Areas.v1.ViewModels
{
    public class CreateEventViewModel
    {
        public string Title { get; set; }
        public DateTime Start { get; set; }
    }

    public class EventViewModel
    {
        public string Title { get; set; }
        public EventOrigin Source { get; set; }
    }

    public enum EventOrigin
    {
        Site,
        Facebook,
        LastFm
    }
}