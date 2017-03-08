using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HiWeb.Controllers
{
    //[Route("api/v1")]
    public class ServiceController : ApiController
    {

        [HttpGet]
        public string DoA()
        {
            return "A";
        }


        [HttpPost]
        public string DoB()
        {
            return "B";
        }


        [HttpGet]
        public string RepondJson()
        {
            return "{\"name\" : \"some stuff\"}";
        }

    }
}
