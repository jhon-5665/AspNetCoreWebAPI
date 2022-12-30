using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly SmartContext _context;

        public TeacherController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Teachers);
        }

        // api/teachers/byId
        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id)
        {                       
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);                       
            if (teacher == null)
            {
                return BadRequest("The teacher was not found.");
            }
            return Ok(teacher);
        }

        // api/teacher/name
        [HttpGet("ByName")]
        public IActionResult GetByName(string name)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Name.Contains(name));
            if (teacher == null)
            {
                return BadRequest("The teacher was not found.");
            }
            return Ok(teacher);
        }

        // api/teacher/
        [HttpPost]
        public IActionResult Post(Teacher teacher)
        {
            _context.Add(teacher);
            _context.SaveChanges();
            return Ok(teacher);
        }

        // api/teacher/
        [HttpPut("{id}")]
        public IActionResult Put(int id, Teacher teacher)
        {
            var tea = _context.Teachers.AsNoTracking().FirstOrDefault(t => t.Id == id);
            if (tea == null)
            {
                return BadRequest("Teacher not found");
            }
            _context.Update(teacher);
            _context.SaveChanges();
            return Ok(teacher);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Teacher teacher)
        {
            var tea = _context.Teachers.AsNoTracking().FirstOrDefault(t => t.Id == id);
            if (tea == null)
            {
                return BadRequest("Teacher not found");
            }
            _context.Update(teacher);
            _context.SaveChanges();
            return Ok(teacher);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
            {
                return BadRequest("Teacher not found");
            }
            _context.Remove(teacher);
            _context.SaveChanges();
            return Ok();
        }
    }
}