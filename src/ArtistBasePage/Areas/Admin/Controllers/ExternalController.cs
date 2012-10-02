using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtistBasePage.Areas.Admin.Controllers
{
    public class ExternalController : Controller
    {
        //
        // GET: /Admin/External/

        public ActionResult LastFm()
        {
            return View();
        }

    }
}
