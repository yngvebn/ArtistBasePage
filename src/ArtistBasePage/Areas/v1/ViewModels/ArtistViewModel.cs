using System.Collections.Generic;
using Domain;

namespace ArtistBasePage.Areas.v1.Controllers
{
    public class ArtistViewModel
    {
        public int Id { get; set; }
        public string Name { get;  set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Bio { get; set; }
        public List<SocialNetworkViewModel> SocialNetworks { get; set; }
    }

    public class SocialNetworkViewModel
    {
        public SocialNetworkType Type { get; set; }
        public string Url { get; set; }
    }
}