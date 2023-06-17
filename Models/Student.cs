using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practice1.Models
{
    public class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birth { get; set; }
        public string Major { get; set; }

        public string PhoneNumber { get; set; }
        public string Sex { get; set; }

        public string ImagePath { get; set; }

        public List<Course> Courses = new List<Course>();

    }
}