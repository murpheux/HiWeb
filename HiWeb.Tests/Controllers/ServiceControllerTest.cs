using HiWeb.Controllers;
using HiWeb.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace HiWeb.Tests.Controllers
{
    public class ServiceControllerTest
    {
        //IRepository fakeRespository;
        ServiceController serviceController;

        public ServiceControllerTest()
        {
            serviceController = new ServiceController();
        }

        [Fact, Trait("Service", "Ops")]
        public void Service_DoA()
        {
            serviceController.DoSomething().ShouldBe("A");
        }

        [Fact, Trait("Service", "Ops")]
        public void Service_DoB()
        {
            serviceController.DoAnotherThing().ShouldBe("B");
        }

        [Fact, Trait("Service", "Ops")]
        public void Service_DoC()
        {
            serviceController.DoSomeOtherThing().ShouldBe("C");
        }

    }
}
