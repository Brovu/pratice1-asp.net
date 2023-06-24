using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
        public ActionResult ListStudent()
        {
            return View(new ManageStudentEntities3().Students.ToList());
        }


        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student model)
        {
            ManageStudentEntities3 students = new ManageStudentEntities3();

            students.Students.Add(model);

            students.SaveChanges();

            return RedirectToAction("ListStudent");
        }

        public ActionResult EditStudent(string idStudent)
        {
            ManageStudentEntities3 students = new ManageStudentEntities3();
            Student model2 = students.Students.Find(idStudent);

            return View(model2);
        }

        [HttpPost]

        public ActionResult EditStudent(Student model)
        {
            ManageStudentEntities3 students = new ManageStudentEntities3();
            var updateModel = students.Students.Find(model.ID);

            updateModel.Name = model.Name;
            updateModel.Birth = model.Birth;
            updateModel.Major = model.Major;
            updateModel.PhoneNumber = model.PhoneNumber;
            updateModel.Sex = model.Sex;
            updateModel.idTypeStudent = model.idTypeStudent;

            students.SaveChanges();
            return RedirectToAction("ListStudent");
        }

        public ActionResult RemoveStudent(string idStudent)
        {
            ManageStudentEntities3 students = new ManageStudentEntities3();
            var delModel = students.Students.Find(idStudent);
            students.Students.Remove(delModel);
            students.SaveChanges();
            return RedirectToAction("ListStudent");
        }

        public ActionResult DetailStudent(string idStudent)
        {
            ManageStudentEntities3 students = new ManageStudentEntities3();
            var model = students.Students.Find(idStudent);

            var courses = students.Courses.Where(c => c.courseID == idStudent).ToList();

            students.Courses = courses;
            return View(model);
        }

        public ActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCourse(Course model, string idStudent)
        {
            ManageStudentEntities3 students = new ManageStudentEntities3();

            var updateStudent = students.Students.Find(idStudent);
            updateStudent.idCourse = model.courseID;

            students.Courses.Add(model);

            students.SaveChanges();
            return RedirectToAction("DetailStudent", new { idStudent = idStudent });
        }

    }
        /*public ActionResult AddStudent()
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
        public ActionResult AddCourse(Course model, string idStudent)
        {
            var updateCourse = ListStudent.listStudent.SingleOrDefault(m => m.ID == idStudent);
            updateCourse.Courses.Add(model);
            return RedirectToAction("DetailStudent", new { idStudent = idStudent });
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

        }*/



    }