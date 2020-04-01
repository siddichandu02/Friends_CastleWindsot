using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WindsorMvcDemo.Models;

namespace WindsorMvcDemo.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container,
        Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<FriendsEntities>()
                    //.ImplementedBy<FriendsEntities>()
                    .LifestyleTransient());
        }
    }
}
