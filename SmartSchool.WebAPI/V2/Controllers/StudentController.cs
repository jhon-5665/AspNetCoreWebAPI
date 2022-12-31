using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.V2.Dtos;
using SmartSchool.WebAPI.Models;


namespace SmartSchool.WebAPI.V2.Controllers
{
    /// <summary>
    /// Version 2 of my students controller
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StudentController : ControllerBase
    {
        public readonly IRepository _repo;
        private readonly IMapper _mapper;


        /// <summary>
        ///
        /// </summary>
        /// <param name="repo"></param>        
        /// <param name="mapper"></param> 
        public StudentController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        
        /// <summary>
        /// Method responsible for returning all my students
        /// </summary>
        /// <returns></returns>  
        [HttpGet]
        public IActionResult Get()
        {
            var students = _repo.GetAllStudents(true);          
            return Ok(_mapper.Map<IEnumerable<StudentDto>>(students));
        }

        /// <summary>
        /// Method responsible for returning only a single StudentDto
        /// </summary>
        /// <returns></returns>  
        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {                   
            return Ok(new StudentRegisterDto());
        }

        /// <summary>
        /// Method responsible for returning only a single Student through the Id
        /// </summary>
        /// <param name="id"></param> 
        /// <returns></returns> 
        // api/student
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _repo.GetStudentById(id, false);
            if (student == null)
            {
                return BadRequest("The student was not found.");
            }

            var studentDto = _mapper.Map<StudentDto>(student);

            return Ok(studentDto);
        }

        [HttpPost]
        public IActionResult Post(StudentRegisterDto model)
        {
            var student = _mapper.Map<Student>(model);

            _repo.Add(student);
            if (_repo.SaveChanges())
            {
                return Created($"/api/student/{model.Id}", _mapper.Map<StudentDto>(student));
            }
            return BadRequest("Unregistered student");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, StudentRegisterDto model)
        {
            var student = _repo.GetStudentById(id);
            if (student == null)
            {
                return BadRequest("Student not found");
            }

            _mapper.Map(model, student);

            _repo.Update(student);
            if (_repo.SaveChanges())
            {
                return Created($"/api/student/{model.Id}", _mapper.Map<StudentDto>(student));
            }
            return BadRequest("Non-updated student");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, StudentRegisterDto model)
        {
            var student = _repo.GetStudentById(id);
            if (student == null)
            {
                return BadRequest("Student not found");
            }

            _mapper.Map(model, student);

            _repo.Update(student);
            if (_repo.SaveChanges())
            {
                return Created($"/api/student/{model.Id}", _mapper.Map<StudentDto>(student));
            }
            return BadRequest("Non-updated student");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _repo.GetStudentById(id);
            if (student == null)
            {
                return BadRequest("Student not found");
            }

            _repo.Delete(student);
            if (_repo.SaveChanges())
            {
                return Ok("Deleted student");
            }
            return BadRequest("Undeleted student");
        }
    }
}