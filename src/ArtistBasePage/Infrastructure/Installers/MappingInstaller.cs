using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Extensions.Conventions;

namespace ArtistBasePage.Infrastructure.Installers
{
    public class MappingInstaller: INinjectInstaller
    {
        public void Install(IKernel kernel)
        {
            kernel.Bind<IMapper>().To<Mapper>().InSingletonScope();
            kernel.Bind(c => c.FromThisAssembly().
                SelectAllClasses().InheritedFrom(typeof(IMapping))
                .BindAllInterfaces());

            kernel.GetAll<IMapping>().ToList().ForEach(m => m.Setup());
        }
    }
}