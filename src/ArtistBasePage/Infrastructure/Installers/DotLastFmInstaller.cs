using ArtistBasePage.Infrastructure.Flickr;
using ArtistBasePage.Infrastructure.LastFm;
using DotLastFm.Api;
using Flickr;
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

    public class FlickrApiInstaller: INinjectInstaller
    {
        public void Install(IKernel kernel)
        {
            kernel.Bind(c => c.FromAssemblyContaining<IFlickrApi>().SelectAllClasses().BindDefaultInterfaces());

            kernel.Bind<IFlickrConfig>().To<FlickrConfig>();
        }
    }
}