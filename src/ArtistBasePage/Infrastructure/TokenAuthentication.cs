using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ArtistBasePage.Areas.v1.Controllers;
using Domain.Core;
using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;

namespace ArtistBasePage.Infrastructure
{
    public class TokenAuthentication : ActionFilterAttribute
    {
        private readonly IArtistRepository _artistRepository;
        private readonly ITokenRepository _tokenRepository;

        public TokenAuthentication(bool requireToken = false)
        {
            RequireToken = requireToken;
            _artistRepository = DependencyResolver.Current.GetService<IArtistRepository>();
            _tokenRepository = DependencyResolver.Current.GetService<ITokenRepository>();
        }

        public bool RequireToken { get; set; }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (!RequireToken)
            {
                base.OnActionExecuting(actionContext);
            }
            else
            {
                var token = actionContext.ControllerContext.Request.Headers.GetValues("t").SingleOrDefault();

                var tc = actionContext.ControllerContext.Controller as TokenApiController;

                if (token == null)
                    throw new HttpException(401, "Token is required");

                var apiToken = _tokenRepository.Get(token);

                if (apiToken == null || !apiToken.IsValid)
                    throw new HttpException(401, "Token has expired");

                tc.ArtistId = apiToken.AssociatedArtist.Id;
                tc.CanWrite = apiToken.IsAuthenticated;


                if (!tc.CanWrite && actionContext.Request.Method != HttpMethod.Get)
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    throw new HttpException(401, "Unauthorized");
                }
                else
                {

                    base.OnActionExecuting(actionContext);
                }
            }

        }
    }
}