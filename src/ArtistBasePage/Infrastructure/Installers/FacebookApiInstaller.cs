using ArtistBasePage.Infrastructure.Facebook;
using Facebook.Api;
using Ninject;
using Ninject.Extensions.Conventions;

namespace ArtistBasePage.Infrastructure.Installers
{
    public class FacebookApiInstaller : INinjectInstaller
    {
        public void Install(IKernel kernel)
        {
            kernel.Bind(c => c.FromAssemblyContaining<IFacebookApi>()
                                 .SelectAllClasses().BindDefaultInterfaces());
            kernel.Bind<IFacebookConfig>().To<FacebookConfig>();
        }
    }
}