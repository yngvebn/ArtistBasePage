﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ArtistBasePage.Areas.Admin.Controllers
{
    public class PicturesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
