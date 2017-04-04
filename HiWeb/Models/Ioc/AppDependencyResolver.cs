using HiMVC.Services;
using HiWeb.Controllers;
using HiWeb.DataContext;
using HiWeb.Interface;
using Microsoft.Extensions.Logging;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HiWeb.Models.Ioc
{
    public class AppDependencyResolver : IDependencyResolver
    {

        private readonly Container _container;
        private readonly IDependencyResolver _instance;

        public AppDependencyResolver(Container container, IDependencyResolver defaultResolver)
        {
            _container = container;
            _instance = defaultResolver;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType is IControllerFactory || serviceType is IRepository
                    || serviceType is ILoggerFactory || serviceType is IEmailSender || serviceType is ISmsSender)
                return _container.GetInstance(serviceType);
            else
                return _instance.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType is IControllerFactory || serviceType is IRepository
                    || serviceType is ILoggerFactory || serviceType is IEmailSender || serviceType is ISmsSender)
                return _container.GetAllInstances(serviceType);
            else
                return _instance.GetServices(serviceType);
        }
    }
}