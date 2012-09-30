using Ninject;

namespace ArtistBasePage.Infrastructure.Installers
{
    public interface INinjectInstaller
    {
        void Install(IKernel kernel);
    }
}