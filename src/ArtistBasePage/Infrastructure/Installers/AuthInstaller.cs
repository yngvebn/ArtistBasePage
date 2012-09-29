using Ninject;

namespace ArtistBasePage.Infrastructure.Installers
{
    public class AuthInstaller: INinjectInstaller
    {
        public void Install(IKernel kernel)
        {
            kernel.Bind<IAuthenticationService>().To<AuthenticationService>();
        }
    }
}