using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practice1.Models;

namespace Practice1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult List()
        {
            return View(ListStudent.listStudent);
        }

        public ActionResult AddStudent()
        {
            return View(new Student());
        }

        [HttpPost]

        public ActionResult AddStudent(Student model, HttpPostedFileBase ImageFile)
        {
            if (ImageFile.ContentLength > 0)
            {
                string rootFolder = Server.MapPath("/Images/");
                string path = rootFolder + ImageFile.FileName;
                ImageFile.SaveAs(path);

                model.ImagePath = "/Images/" + ImageFile.FileName;
            }

            ListStudent.listStudent.Add(model);
            return RedirectToAction("List");
        }

        public ActionResult EditStudent(string idStudent)
        {
            var student = ListStudent.listStudent.SingleOrDefault(m => m.ID == idStudent);
            return View(student);
        }

        [HttpPost]

        public ActionResult EditStudent(Student model)
        {
            var student = ListStudent.listStudent.SingleOrDefault(m => m.ID == model.ID);

            student.Name = model.Name;
            student.Birth = model.Birth;
            student.Major = model.Major;
            student.PhoneNumber = model.PhoneNumber;
            student.ImagePath = model.ImagePath;

            return RedirectToAction("List");

        }

        public ActionResult RemoveStudent(string idStudent)
        {
            var student = ListStudent.listStudent.SingleOrDefault(m => m.ID == idStudent);
            ListStudent.listStudent.Remove(student);
            return RedirectToAction("List");

        }

        public ActionResult DetailStudent(string idStudent)
        {
            var student = ListStudent.listStudent.SingleOrDefault(m => m.ID == idStudent);
            return View(student);
        }

        public ActionResult AddCourse()
        {
            return View(new Course());
        }

        [HttpPost]
        public ActionResult AddCourse(Course model,string idStudent)
        {
            var updateCourse = ListStudent.listStudent.SingleOrDefault(m => m.ID == idStudent);
            updateCourse.Courses.Add(model);
            return RedirectToAction("DetailStudent", new {idStudent = idStudent});
        }

        public ActionResult RemoveCourse(string idStudent, string idCourse)
        {
            var updateCourse = ListStudent.listStudent.SingleOrDefault(m => m.ID == idStudent);
            var courses = updateCourse.Courses.SingleOrDefault(m => m.courseID == idCourse);
            updateCourse.Courses.Remove(courses);
            return RedirectToAction("DetailStudent", new { idStudent = idStudent });
        }

        public ActionResult UpdateCourse(string idStudent, string idCourse)
        {
            var updateCourse = ListStudent.listStudent.SingleOrDefault(m => m.ID == idStudent);
            var courses = updateCourse.Courses.SingleOrDefault(m => m.courseID == idCourse);
            return View(courses);
        }

        [HttpPost]
        public ActionResult UpdateCourse(string idStudent, string idCourse, Course model)
        {
            var updateCourse = ListStudent.listStudent.SingleOrDefault(m => m.ID == idStudent);
            var courses = updateCourse.Courses.SingleOrDefault(m => m.courseID == idCourse);

            courses.courseName = model.courseName;
            courses.courseCredits = model.courseCredits;
            courses.courseTeacher = model.courseTeacher;
            return RedirectToAction("DetailStudent", new { idStudent = idStudent });

        }



    }
}