using HiWeb.DataContext;
using HiWeb.Interface;
using HiWeb.Models.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HiWeb.Controllers
{
    public class HomeController : BaseController
    {
        //public HomeController(IRepository repository, ILoggerFactory loggerFactory, IOptions<AppKeyConfig> appkeys)
        //    : base(repository, loggerFactory, appkeys)
        //{ }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}