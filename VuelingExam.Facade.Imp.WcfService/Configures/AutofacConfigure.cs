using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VuelingExam.Facade.Imp.WcfService.Modules;

namespace VuelingExam.Facade.Imp.WcfService.Configures
{
    public class AutofacConfigure
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new UniversityWcfModule());

            var container = builder.Build();

            /*var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;*/

            return container;
        }
    }
}