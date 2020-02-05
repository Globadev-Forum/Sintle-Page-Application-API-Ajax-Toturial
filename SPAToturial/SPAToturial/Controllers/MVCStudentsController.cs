using SPAToturial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPAToturial.Controllers
{
    public class MVCStudentsController : Controller
    {
        private static List<Student> Students = new List<Student>() {
                    new Student() { StudentId = 1, StudentName = "John", Age = 18 },
                    new Student() { StudentId = 2, StudentName = "Steve", Age = 21 },
                    new Student() { StudentId = 3, StudentName = "Bill", Age = 25 },
                    new Student() { StudentId = 4, StudentName = "Ram", Age = 20 },
                    new Student() { StudentId = 5, StudentName = "Ron", Age = 31 },
                    new Student() { StudentId = 6, StudentName = "Chris", Age = 17 },
                    new Student() { StudentId = 7, StudentName = "Rob", Age = 19 }
        };

        // GET: Students
        [HttpGet]
        public ActionResult Get()
        {
            var Result = Students;
            return Json(Result, JsonRequestBehavior.AllowGet);
        }


        // GET: Students
        [HttpGet]
        public ActionResult GetById(int Id)
        {
            var Result = Students.Where(x=>x.StudentId==Id).FirstOrDefault();
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Post(Student Std)
        {
            Std.StudentId = Students.Max(x => x.StudentId) + 1;
            Students.Add(Std);            
            return Json(Std);
        }

        [HttpPut]
        public ActionResult Put(Student Std)
        {
            var OldStd = Students.Where(x => x.StudentId == Std.StudentId).FirstOrDefault();
            OldStd.StudentName = Std.StudentName;
            OldStd.Age = Std.Age;
            return Json(OldStd);
        }

        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            var OldStd = Students.Where(x => x.StudentId == Id).FirstOrDefault();
            Students.Remove(OldStd);
            return Json(OldStd);
        }


    }
}