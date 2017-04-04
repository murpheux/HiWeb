using HiMVC.Services;
using HiWeb.Controllers;
using HiWeb.DataContext;
using HiWeb.Interface;
using Microsoft.Extensions.Logging;
using SimpleInjector;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace HiWeb.Models.Ioc
{
    public class AppControllerFactory : IControllerFactory
    {
        Container _container;

        public AppControllerFactory(Container container)
        {
            _container = container;
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            IRepository repository = _container.GetInstance<IRepository>();
            ILoggerFactory loggerFactory = _container.GetInstance<ILoggerFactory>();

            var controller = new HomeController(repository, loggerFactory);
            return controller;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
}