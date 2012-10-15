using System;

namespace ArtistBasePage.Areas.v1.ViewModels
{
    public class CreateEventViewModel
    {
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public string FacebookEventId { get; set; }
    }
}