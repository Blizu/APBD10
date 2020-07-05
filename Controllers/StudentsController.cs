using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APBD10.Models;

namespace APBD10.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            var db = new localDBContext();

            return Ok(db.Student.ToList());
        }

        [HttpPut("{indexNumber}")]
        public IActionResult UpdateStudent(string indexNumber, Student studentDto)
        {
            var db = new localDBContext();

            var student = db.Student
                .Where(s => s.IndexNumber == indexNumber)
                .Single();

            student.FirstName = studentDto.FirstName;
            student.LastName = studentDto.LastName;
            db.SaveChanges();

            return Ok(student);
        }

        [HttpDelete("{indexNumber}")]
        public IActionResult RemoveStudent(string indexNumber)
        {
            var db = new localDBContext();

            var student = db.Student
                .Where(s => s.IndexNumber == indexNumber)
                .Single();

            db.Remove(student);
            db.SaveChanges();

            return Ok();
        }
    }
}