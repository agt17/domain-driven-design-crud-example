using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExam.Common.Logic.Logging.Adapters;
using VuelingExam.Common.Logic.Logging.Interfaces;
using VuelingExam.Domain.BusinessEntities;
using VuelingExam.Domain.Impl.Services.Modules;
using VuelingExam.Infrastructure.Contracts.Repository.Interfaces;
using VuelingExam.Infrastructure.DataModel;
using VuelingExam.Infrastructure.Impl.Repository.Modules;
using VuelingExam.Infrastructure.Impl.Repository.Repositories;

namespace VuelingExam.Application.Business.Impl.ServiceLibrary.Modules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterModule(new DomainModule());

            builder.RegisterModule(new InfrastructureModule());

            builder
                .RegisterType<StudentRepository>()
                .As<IStudentRepository<StudentEntity, Student>>()
                .InstancePerRequest();

            builder
                .RegisterType<SerilogAdapter>()
                .As<ILogger>();

            base.Load(builder);
        }
    }
}
