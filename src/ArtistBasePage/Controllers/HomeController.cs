using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Commands;
using Domain.Core;

namespace ArtistBasePage.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
