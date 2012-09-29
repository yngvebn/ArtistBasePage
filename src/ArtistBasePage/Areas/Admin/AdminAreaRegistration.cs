using System.Web.Mvc;

namespace ArtistBasePage.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("token",
                             "token/get",
                             new { controller = "Token", action = "RequestToken", id = UrlParameter.Optional });

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "General", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
