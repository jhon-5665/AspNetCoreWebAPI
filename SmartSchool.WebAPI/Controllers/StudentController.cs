using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly SmartContext _context;

        public StudentController(SmartContext context)
        {
            _context = context;
        }            

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Students);
        }

        // api/student/byId
        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id)
        {                       
            var student = _context.Students.FirstOrDefault(s => s.Id == id);                       
            if (student == null)
            {
                return BadRequest("The student was not found.");
            }
            return Ok(student);
        }

        // api/student/name
        [HttpGet("ByName")]
        public IActionResult GetByName(string name, string surname)
        {
            var student = _context.Students.FirstOrDefault(s => s.Name.Contains(name) && s.Surname.Contains(surname));
            if (student == null)
            {
                return BadRequest("The student was not found.");
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            var stud = _context.Students.AsNoTracking().FirstOrDefault(s => s.Id == id);
            if (stud == null)
            {
                return BadRequest("Student not found");
            }
            _context.Update(student);
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Student student)
        {
            var stud = _context.Students.AsNoTracking().FirstOrDefault(s => s.Id == id);
            if (stud == null)
            {
                return BadRequest("Student not found");
            }
            _context.Update(student);
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return BadRequest("Student not found");
            }
            _context.Remove(student);
            _context.SaveChanges();
            return Ok();
        }
    }
}