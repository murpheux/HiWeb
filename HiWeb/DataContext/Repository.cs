using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiWeb.DataContext
{
    public class Repository : IRepository
    {
        public string DoAnotherThing()
        {
            return "Some mother do have them!";
        }

        public string SayHello()
        {
            return "Hello World!";
        }
    }
}