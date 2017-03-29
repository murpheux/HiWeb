using HiWeb.DataContext;
using HiWeb.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HiWeb.Controllers
{
    public class HomeController : Controller
    {
        IRepository _respository;
        ILogger _logger;

        public HomeController() { }

        public HomeController(IRepository repository, ILogger logger)
        {
            _respository = repository;
            _logger = logger;
        }

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