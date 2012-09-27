using Domain.Core;
using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Interception.Infrastructure.Language;

namespace ArtistBasePage.Infrastructure.Installers
{
    public class CommandsInstaller: INinjectInstaller
    {
        public void Install(IKernel kernel)
        {
            kernel.Bind<ICommandExecutor>().To<CommandExecutor>();

            kernel.Bind(c => c.FromAssemblyContaining<IArtistRepository>().
                SelectAllClasses().InheritedFrom(typeof(ICommandHandler<>))
                .BindAllInterfaces());

            kernel.Intercept(InterceptSetup).With<SessionAndTransactionWrapper>();
        }

        private bool InterceptSetup(IContext obj)
        {
            return obj.Binding.Service.FullName.Contains("ICommandHandler");
        }
    }
}