using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VuelingExam.Application.Business.Contract.ServiceLibrary;
using VuelingExam.Application.Business.Impl.ServiceLibrary;
using VuelingExam.Application.Business.Impl.ServiceLibrary.Modules;
using VuelingExam.Common.Logic.Logging.Adapters;
using VuelingExam.Common.Logic.Logging.Interfaces;

namespace VuelingExam.Facade.Imp.WcfService.Modules
{
    public class UniversityWcfModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<UniversityApplication>()
                .As<IUniversityApplication>()
                .InstancePerRequest();

            builder
                .RegisterType<SerilogAdapter>()
                .As<ILogger>();

            builder.RegisterModule(new ApplicationModule());

            base.Load(builder);
        }
    }
}