using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            builder.RegisterModule(new InfrastructureModule());

            builder
                .RegisterType<EnrollmentRepository>()
                .As<IRepository<Enrollment>>()
                .InstancePerRequest();

            builder
                .RegisterType<StudentRepository>()
                .As<IRepository<Student>>()
                .InstancePerRequest();

            builder
                .RegisterType<SubjectRepository>()
                .As<IRepository<Subject>>()
                .InstancePerRequest();

            base.Load(builder);
        }
    }
}
