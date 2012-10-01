using System;
using System.Collections.Generic;

namespace ArtistBasePage.Areas.v1.Controllers
{
    public class ArtistViewModel
    {
        public string Name { get;  set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Bio { get; set; }
        public DateTime Created { get; set; }
    }
}