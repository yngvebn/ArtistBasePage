using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ArtistBasePage.Areas.Admin.ViewModels;
using ArtistBasePage.Areas.v1.Controllers;
using ArtistBasePage.Infrastructure;
using Domain;
using Domain.Commands;
using Domain.Core;

namespace ArtistBasePage.Areas.Admin.Controllers
{
    public class AuthenticateController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenRepository _tokenRepository;
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IArtistRepository _artistRepository;

        public AuthenticateController(IMapper mapper, IAuthenticationService authenticationService, ITokenRepository tokenRepository, IUserLoginRepository userLoginRepository, IArtistRepository artistRepository)
        {
            _mapper = mapper;
            _authenticationService = authenticationService;
            _tokenRepository = tokenRepository;
            _userLoginRepository = userLoginRepository;
            _artistRepository = artistRepository;
        }

        public ActionResult Login()
        {
            return View();
        }

        [Authorize]
        public ActionResult SelectArtist(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            var artists = _userLoginRepository.Get(User.Identity.Name).Artists;
            return View(_mapper.Map<IEnumerable<ArtistViewModel>>(artists).Select(model => new SelectListItem()
                                                                                               {
                                                                                                   Text = model.Name,
                                                                                                   Value = model.Id.ToString()
                                                                                               }));
        }

        [Authorize]
        [HttpPost]
        public ActionResult SelectArtist(int artist, string returnUrl)
        {
            Guid correlationId = Guid.NewGuid();
            
            var result = MvcApplication.CommandExecutor.ExecuteCommand(new CreateReadWriteToken()
            {
                ArtistId =artist,
                CorrelationId = correlationId
            });
            var token = _tokenRepository.GetByCorrelationId(correlationId);
            Session.Remove("token");
            Session.Add("token", token.Token);
            return Redirect(string.IsNullOrEmpty(returnUrl) ? "/admin/general/index" : returnUrl);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterNewUserViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                MvcApplication.CommandExecutor.ExecuteCommand(new RegisterNewUserCommand()
                                                                  {
                                                                      Username = viewModel.Username,
                                                                      Password = viewModel.Password
                                                                  });
                _authenticationService.Login(viewModel.Username);
                return Redirect("/admin/general/newartist");
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string returnUrl = null)
        {
            if(_authenticationService.Validate(username, password))
            {
                _authenticationService.Login(username);    
            }
            else
            {
                return View();
            }

            var artists = _authenticationService.GetUserArtists(username, password);
            var userArtists = artists as Artist[] ?? artists.ToArray();
            
            if (userArtists.Any())
            {
                
                if (userArtists.Count() == 1)
                {
                    Guid correlationId = Guid.NewGuid();
                   MvcApplication.CommandExecutor.ExecuteCommand(new CreateReadWriteToken()
                       {
                           ArtistId = userArtists.First().Id,
                           CorrelationId = correlationId
                       });
                   var token = _tokenRepository.GetByCorrelationId(correlationId);
                    Session.Remove("token");
                    Session.Add("token", token.Token);
                    return string.IsNullOrEmpty(returnUrl) ? Redirect("/admin/general/index") : Redirect(returnUrl);
                }
                else
                {
                    return string.IsNullOrEmpty(returnUrl) ? Redirect("/admin/authenticate/selectartist?returnUrl=" + returnUrl) : Redirect("/admin/authenticate/selectartist");
                }
            }
            else
            {
                return Redirect("/admin/general/newartist");
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