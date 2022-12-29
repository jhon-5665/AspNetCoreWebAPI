using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        public List<Student> Students = new List<Student>() 
        {
            new Student()
            {
                Id = 1,
                Name = "Marcos",
                Surname = "Almeida",
                Telephone = "12345658"
            },            
            new Student()
            {
                Id = 2,
                Name = "Marta",
                Surname = "Kent",
                Telephone = "546464"
            },
            new Student()
            {
                Id = 3,
                Name = "Laura",
                Surname = "Maria",
                Telephone = "564564564"
            },
        };

        public StudentController(){}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Students);
        }

        // api/student/byId
        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id)
        {   
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return BadRequest("The student was not found.");           
            }
            return Ok(student);
        }

        // api/student/nome
        [HttpGet("ByName")]
        public IActionResult GetByName(string name, string surname)
        {   
            var student = Students.FirstOrDefault(s => s.Name.Contains(name) && s.Surname.Contains(surname));
            if (student == null)
            {
                return BadRequest("The student was not found.");           
            }
            return Ok(student);
        }
        
        [HttpPost]
        public IActionResult Post(Student student)
        {  
           return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {  
           return Ok(student);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Student student)
        {  
           return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {  
           return Ok();
        }
    }
}