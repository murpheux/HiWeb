using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiWeb.Models
{
    public class Person
    {

        public string Lastname { get; set; }

        public string Othernames { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public SexType Sex { get; set; }
    }

    public enum SexType
    {
        Male,
        Female
    }
}