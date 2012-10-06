using System.Web.Mvc;

namespace ArtistBasePage.Areas.Admin.Controllers
{
    [Authorize]
    public class EventsController: Controller
    {
         public ActionResult Index()
         {
             return View();
         }
    }
}