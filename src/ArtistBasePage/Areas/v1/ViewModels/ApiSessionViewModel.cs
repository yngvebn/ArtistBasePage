using System;

namespace ArtistBasePage.Areas.v1.ViewModels
{
    public class ApiSessionViewModel
    {
        public string Token { get; set; }
        public DateTime ValidUntil { get; set; }
        public DateTime Issued { get; set; }
    }
}