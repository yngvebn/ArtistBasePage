using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using ArtistBasePage.Areas.v1.Controllers;

namespace ArtistBasePage.Infrastructure
{
    public class TokenAuthentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var tc = actionContext.ControllerContext.Controller as TokenApiController;
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