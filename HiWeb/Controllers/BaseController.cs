using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HiWeb.Interface;
using HiWeb.Models.Domain;

namespace HiWeb.Controllers
{
    public partial class BaseController : Controller
    {
        //protected readonly IRepository _repository;
        //protected readonly IOptions<AppKeyConfig> _appkeys;
        //protected readonly ILogger _logger;

        //public BaseController(IRepository repository, ILoggerFactory loggerFactory, IOptions<AppKeyConfig> appkeys)
        //{
        //    _repository = repository;
        //    _appkeys = appkeys;
        //    _logger = loggerFactory.CreateLogger<HomeController>();
        //}

        protected const int PageSize = 20;

    }
}