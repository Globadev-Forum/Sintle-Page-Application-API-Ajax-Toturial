using SPAToturial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SPAToturial.API
{
    [RoutePrefix("api/Students")]
    public class StudentsClassController : ApiController
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
        [Route("")]
        public List<Student> Get()
        {
            var Result = Students;
            return Result;
        }


        // GET: Students
        [HttpGet]
        [Route("{Id}")]
        public Student GetById(int Id)
        {
            var Result = Students.Where(x => x.StudentId == Id).FirstOrDefault();
            return Result;
        }

        [HttpPost]
        [Route("")]
        public Student Post(Student Std)
        {
            Std.StudentId = Students.Max(x => x.StudentId) + 1;
            Students.Add(Std);
            return Std;
        }

        [HttpPut]
        [Route("")]
        public Student Put(Student Std)
        {
            var OldStd = Students.Where(x => x.StudentId == Std.StudentId).FirstOrDefault();
            OldStd.StudentName = Std.StudentName;
            OldStd.Age = Std.Age;
            return OldStd;
        }

        [HttpDelete]
        [Route("{Id}")]
        public Student Delete(int Id)
        {
            var OldStd = Students.Where(x => x.StudentId == Id).FirstOrDefault();
            Students.Remove(OldStd);
            return OldStd;
        }
    }
}
