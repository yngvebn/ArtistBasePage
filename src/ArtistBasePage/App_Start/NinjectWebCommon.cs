using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using ArtistBasePage.Infrastructure.Installers;
using Infrastructure.DomainEvents;
using Ninject.Web.Mvc;

[assembly: WebActivator.PreApplicationStartMethod(typeof(ArtistBasePage.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(ArtistBasePage.App_Start.NinjectWebCommon), "Stop")]

namespace ArtistBasePage.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using Ninject.Extensions.Interception;
    using Ninject.Extensions.Factory;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            GlobalConfiguration.Configuration.DependencyResolver = new ArtistBasePage.Infrastructure.NinjectDependencyResolver(kernel);
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            kernel.Bind(c => c.FromThisAssembly().
                            SelectAllClasses().InheritedFrom<INinjectInstaller>()
                            .BindAllInterfaces());
            DomainEvents.Container = kernel;
            RegisterServices(kernel);
            
            
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.GetAll<INinjectInstaller>().ToList().ForEach(c => c.Install(kernel));
        }        
    }
}
