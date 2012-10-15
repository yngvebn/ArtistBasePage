using System.Web.Mvc;

namespace ArtistBasePage.Areas.Admin.Controllers
{
    [Authorize]
    public class MusicController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}