using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingExam.Domain.Impl.Services.Modules;

namespace VuelingExam.Application.Business.Impl.ServiceLibrary.Modules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterModule(new DomainModule());

            base.Load(builder);
        }
    }
}
