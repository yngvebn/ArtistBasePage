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
        private readonly IArtistRepository _artistRepository;

        public HomeController(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public ActionResult Index()
        {
            MvcApplication.CommandExecutor.ExecuteCommandAsync(new AsyncCommandTest()
                                                              {
                                                                  Hello = "lakdsjf"
                                                              });
            return View();
        }

    }
}
