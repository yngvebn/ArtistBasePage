using System.Data.Entity;
using Domain;
using Domain.Core;
using Infrastructure.Commands;
using Ninject;
using Ninject.Web.Common;
using Ninject.Extensions.Factory;

namespace ArtistBasePage.Infrastructure.Installers
{
    public class SessionManagerInstaller: INinjectInstaller
    {
        public void Install(IKernel kernel)
        {
            kernel.Bind<ISessionManager>().To<SessionManager>();
            kernel.Bind<ISessionManagerInternal>().ToFactory();

            kernel.Bind<DbContext>().To<Db>().InRequestScope();
        }
    }
}