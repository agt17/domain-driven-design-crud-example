using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExam.Common.Logic.Logging.Adapters;
using VuelingExam.Common.Logic.Logging.Interfaces;

namespace VuelingExam.Infrastructure.Impl.Repository.Modules
{
    public class InfrastructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<SerilogAdapter>()
                .As<ILogger>();

            base.Load(builder);
        }
    }
}
