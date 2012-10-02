using Domain.Core;
using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Infrastructure.Language;

namespace ArtistBasePage.Infrastructure.Installers
{
    public class RepositoryInstaller: INinjectInstaller
    {
        public void Install(IKernel kernel)
        {
            kernel.Bind<IArtistRepository>().To<ArtistRepository>();
            kernel.Bind<ITokenRepository>().To<TokenRepository>();
            kernel.Bind<IUserLoginRepository>().To<UserLoginRepository>();
            kernel.Bind<ILastFmExternalRepository>().To<LastFmExternalRepository>();
        }
    }
}