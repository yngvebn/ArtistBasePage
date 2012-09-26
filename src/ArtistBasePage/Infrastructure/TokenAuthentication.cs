using System.Web.Mvc;

namespace ArtistBasePage.Infrastructure
{
    public class TokenAuthentication: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var token = filterContext.HttpContext.Request.Headers["Token"];
            base.OnActionExecuting(filterContext);
        }
    }
}