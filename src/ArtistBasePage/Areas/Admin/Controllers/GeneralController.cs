using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtistBasePage.Infrastructure;

namespace ArtistBasePage.Areas.Admin.Controllers
{
    public class GeneralController : Controller
    {
        private readonly IMapper _mapper;
        //
        // GET: /Admin/Main/
        public GeneralController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
