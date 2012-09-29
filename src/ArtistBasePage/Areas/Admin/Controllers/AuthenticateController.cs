using System.Web.Mvc;
using ArtistBasePage.Infrastructure;

namespace ArtistBasePage.Areas.Admin.Controllers
{
    public class AuthenticateController: Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticateController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string returnUrl = null)
        {
            if(_authenticationService.Validate(username, password))
            {
                _authenticationService.Login(username);
                return string.IsNullOrEmpty(returnUrl) ? Redirect("/admin/general/index") : Redirect(returnUrl);
            }
            return View();
        }

        public ActionResult Logout()
        {
            _authenticationService.Logout();
            return RedirectToAction("Login");
        }

    }
}