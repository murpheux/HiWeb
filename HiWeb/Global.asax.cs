using HiMVC.Services;
using HiWeb.DataContext;
using HiWeb.Interface;
using HiWeb.Models.Ioc;
using Microsoft.Extensions.Logging;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HiWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // IOC
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<IControllerFactory>(() => new AppControllerFactory(container));
            container.Register<IRepository, Repository>();
            container.Register<ILoggerFactory, LoggerFactory>(Lifestyle.Singleton);
            container.Register<IEmailSender, AuthMessageSender>();
            container.Register<ISmsSender, AuthMessageSender>();

            var registration = container.GetRegistration(typeof(ILoggerFactory)).Registration;
            registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "as I want it");

            //container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            //GlobalConfiguration.Configuration.DependencyResolver =
            //    (IDependencyResolver) new AppDependencyResolver(container, DependencyResolver.Current);

            DependencyResolver.SetResolver(new AppDependencyResolver(container, DependencyResolver.Current));
        }
    }
}
