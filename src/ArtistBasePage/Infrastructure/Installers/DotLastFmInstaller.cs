using ArtistBasePage.Infrastructure.LastFm;
using DotLastFm.Api;
using Ninject;
using Ninject.Extensions.Conventions;

namespace ArtistBasePage.Infrastructure.Installers
{
    public class DotLastFmInstaller: INinjectInstaller
    {
        public void Install(IKernel kernel)
        {
            kernel.Bind(c => c.FromAssemblyContaining<ILastFmApi>()
                                 .SelectAllClasses().BindDefaultInterfaces());
            kernel.Bind<ILastFmConfig>().To<LastFmConfig>();
        }
    }
}