using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HiWeb.ViewModel
{
    public class StudentModel
    {
        public int StudentId { get; set; }

        [Display(Name = "Fullname")]
        public string Name { get; internal set; }

        public int Age { get; internal set; }

        public string Sex { get; internal set; }

        public string Email { get; internal set; }

        public string Address { get; internal set; }
    }
}