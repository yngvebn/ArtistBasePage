using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Infrastructure.Commands;
using Ninject;
using SignalR;
using SignalR.Ninject;

namespace ArtistBasePage
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalHost.DependencyResolver = new NinjectDependencyResolver(DependencyResolver.Current.GetService<IKernel>());
            RouteTable.Routes.MapHubs();
            AreaRegistration.RegisterAllAreas();
            
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
        }

        public static ICommandExecutor CommandExecutor {get { return DependencyResolver.Current.GetService<ICommandExecutor>(); }}

     
    }
}