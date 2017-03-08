using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiWeb.Models
{
    public class Student : Person
    {
        public int StudentId { get; set; }

        IEnumerable<SubjectTest> TestScores { get; set; }
    }
}