using HiWeb.DataContext;
using HiWeb.Interface;
using HiWeb.Models.Domain;
using HiWeb.ViewModel;
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
        public HomeController()
            : base()
        { }

        public HomeController(IRepository repository, ILoggerFactory loggerFactory)//, IOptions<AppKeyConfig> appkeys)
            : base(repository, loggerFactory)
        { }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {

            return View();
        }

        public ActionResult List()
        {
            var list = new List<StudentModel>
            {
                new StudentModel() { Name = "Clement Onawole", Sex = "M", Age = 40 },
                new StudentModel() { Name = "Seun Bukari", Sex = "F", Age = 22 }
            };

            return View(list);
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