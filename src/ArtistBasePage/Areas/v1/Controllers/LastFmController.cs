using System.Web.Http;
using Domain.Commands;

namespace ArtistBasePage.Areas.v1.Controllers
{
    public class LastFmController: TokenApiController
    {
        [HttpPost]
        public void Connect()
        {
            Execute(new ConnectArtistToLastFm()
                        {
                            ArtistId = ArtistId
                        });
        }
    }
}