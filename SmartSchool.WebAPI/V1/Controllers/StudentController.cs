using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.V1.Dtos;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Helpers;

namespace SmartSchool.WebAPI.V1.Controllers
{
    /// <summary>
    /// Version 1 of my students controller
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
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
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            var students = await _repo.GetAllStudentsAsync(pageParams, true); 

            var studentsResult = _mapper.Map<IEnumerable<StudentDto>>(students);

            Response.AddPagination(students.CurrentPage, students.PageSize, students.TotalCount, students.TotalPages);

            return Ok(studentsResult);
        }

        /// <summary>
        /// Method responsible for returning only a single StudentDto
        /// </summary>
        /// <returns></returns>  
        [HttpGet("ByDiscipline/{id}")]
        public async Task<IActionResult> GetByDisciplineId(int id)
        {                   
            var result = await _repo.GetAllStudentsByDisciplineIdAsync(id, false);
            return Ok(result);
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

            var studentDto = _mapper.Map<StudentRegisterDto>(student);

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
        public IActionResult Patch(int id, StudentPatchDto model)
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
                return Created($"/api/student/{model.Id}", _mapper.Map<StudentPatchDto>(student));
            }
            return BadRequest("Non-updated student");
        }

        // api/student/{id}/changeState
        [HttpPatch("{id}/changeState")]
        public IActionResult ChangeState(int id, ChangeStateDto changeState)
        {
            var student = _repo.GetStudentById(id);
            
            if (student == null)
            {
                return BadRequest("Student not found");         
            }
            student.Active = changeState.State;

            _repo.Update(student);
            if (_repo.SaveChanges())
            {
               var msn = student.Active ? "activated" : "disabled";
               return Ok(new {message = $"Successfully {msn} student!"});
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