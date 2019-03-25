using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using VuelingExam.Application.Business.Impl.ServiceLibrary.Modules;
using VuelingExam.Facade.Imp.WcfService.Configures;

namespace VuelingExam.Facade.Imp.WcfService
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            /*IContainer container = AutofacContainerBuilder.BuildContainer();
            Autofac*/
            //builder.RegisterModule(ApplicationModule);
            AutofacConfigure.Configure();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}