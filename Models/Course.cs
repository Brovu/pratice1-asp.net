using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice1.Models
{
    public class Course
    {
        public string courseID { get; set; }
        public string courseName { get; set; }
        public int courseCredits { get; set; }
        public string courseTeacher { get; set; }
    }
}