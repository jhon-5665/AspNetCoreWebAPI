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
        private readonly IRepository _repo;

        public TeacherController(IRepository repo)
        {
            _repo = repo;            
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllTeachers(true);
            return Ok(result);
        }

        // api/teachers
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {                       
            var teacher = _repo.GetTeacherById(id, false);                       
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
            _repo.Add(teacher);
            if (_repo.SaveChanges())
            {
                return Ok(teacher);
            }
            return BadRequest("Unregistered teacher");
        }

        // api/teacher
        [HttpPut("{id}")]
        public IActionResult Put(int id, Teacher teacher)
        {
            var tea = _repo.GetTeacherById(id, false);
            if (tea == null)
            {
                return BadRequest("Teacher not found");
            }

            _repo.Update(teacher);
            if (_repo.SaveChanges())
            {
                return Ok(teacher);
            }
            return BadRequest("Non-updated teacher");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Teacher teacher)
        {
            var tea = _repo.GetTeacherById(id, false);
            if (tea == null)
            {
                return BadRequest("Teacher not found");
            }
            
            _repo.Update(teacher);
            if (_repo.SaveChanges())
            {
                return Ok(teacher);
            }
            return BadRequest("Non-updated teacher");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = _repo.GetTeacherById(id, false);
            if (teacher == null)
            {
                return BadRequest("Teacher not found");
            }

            _repo.Delete(teacher);
            if (_repo.SaveChanges())
            {
                return Ok("Deleted teacher");
            }
            return BadRequest("Undeleted teacher");
        }
    }
}