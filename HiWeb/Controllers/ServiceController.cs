using HiWeb.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HiWeb.Controllers
{
    //[Route("api/v1")]
    public class ServiceController : ApiController
    {
        [HttpGet]
        public string Index()
        {
            return "My service v1 ...";
        }

        [HttpGet]
        public string DoSomething()
        {
            return "A";
        }


        [HttpGet]
        public string DoAnotherThing()
        {
            return "B";
        }

        [HttpGet]
        public string DoSomeOtherThing()
        {
            return "C";
        }


        [HttpGet]
        public async Task<string> DoJson2()
        {
            Task<string> task = Task.Factory.StartNew(() =>
            {
                return JObject.Parse("{'Service Name' : 'Murpheux Service v1.0'}").ToString(Formatting.None);
            });
            await task;

            return task.Result;
        }

        [HttpGet]
        public async Task<JObject> DoJson()
        {
            Task<JObject> task = Task.Factory.StartNew(() =>
            {
                return JObject.Parse("{'Service Name' : 'Murpheux Service v1.0'}");
            });
            await task;

            return task.Result;
        }

        [HttpGet]
        public IEnumerable<Student> List()
        {
            var list = new List<Student>();

            list.Add(new Student() { Lastname = "Onawole", Othernames = "Clement" });
            list.Add(new Student() { Lastname = "Adewole", Othernames = "Francis" });

            return list;
        }

    }
}
