using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExam.Common.Logic.Logging.Adapters;
using VuelingExam.Common.Logic.Logging.Interfaces;
using VuelingExam.Domain.BusinessEntities;
using VuelingExam.Infrastructure.Contracts.Repository.Interfaces;
using VuelingExam.Infrastructure.DataModel;
using VuelingExam.Infrastructure.Impl.Repository.Modules;
using VuelingExam.Infrastructure.Impl.Repository.Repositories;

namespace VuelingExam.Domain.Impl.Services.Modules
{
    public class DomainModule : Autofac.Module
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
