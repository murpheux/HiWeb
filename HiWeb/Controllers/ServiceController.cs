using HiWeb.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HiWeb.Controllers
{
    [System.Web.Mvc.RequireHttps, System.Web.Mvc.HandleError]
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
            var task = Task.Factory.StartNew(() => JObject.Parse("{'Service Name' : 'Murpheux Service v1.0'}").ToString(Formatting.None));
            await task;

            return task.Result;
        }

        [HttpGet]
        public async Task<JObject> DoJson()
        {
            var task = Task.Factory.StartNew(() => JObject.Parse("{'Service Name' : 'Murpheux Service v1.0'}"));
            await task;

            return task.Result;
        }

        [HttpGet]
        public IEnumerable<Student> List()
        {
            var list = new List<Student>
            {
                new Student() {Lastname = "Onawole", Othernames = "Clement"},
                new Student() {Lastname = "Adewole", Othernames = "Francis"}
            };


            return list;
        }

    }
}
