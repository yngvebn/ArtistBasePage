using Domain.Core;
using Infrastructure.DomainEvents;
using Ninject;
using Ninject.Extensions.Conventions;

namespace ArtistBasePage.Infrastructure.Installers
{
    public class DomainEventsInstaller: INinjectInstaller
    {
        public void Install(IKernel kernel)
        {
            kernel.Bind(c => c.FromAssemblyContaining<IArtistRepository>().
                SelectAllClasses().InheritedFrom(typeof(IDomainEventHandler<>))
                .BindAllInterfaces());
        }
    }
}