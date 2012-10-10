using Ninject;
using Ninject.Extensions.Conventions;

namespace ArtistBasePage.Infrastructure.Installers
{
    public class OrchestratorInstaller: INinjectInstaller
    {
        public void Install(IKernel kernel)
        {
            kernel.Bind(c => c.FromThisAssembly()
                                 .SelectAllClasses().EndingWith("Orchestrator").BindDefaultInterfaces());
        }
    }
}