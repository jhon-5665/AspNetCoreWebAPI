using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.V1.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly IRepository _repo;

        private readonly IMapper _mapper;

        public TeacherController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;            
        }

        [HttpGet]
        public IActionResult Get()
        {
            var teacher = _repo.GetAllTeachers(true);          
            return Ok(_mapper.Map<IEnumerable<TeacherDto>>(teacher));
        }

        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {                   
            return Ok(new TeacherRegisterDto());
        }

        // api/teachers
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {                       
            var teacher = _repo.GetTeacherById(id, true);                       
            if (teacher == null)
            {
                return BadRequest("The teacher was not found.");
            }

            var teacherDto = _mapper.Map<TeacherDto>(teacher);

            return Ok(teacher);
        }        
       
        // api/teacher/
        [HttpPost]
        public IActionResult Post(TeacherRegisterDto model)
        {
            var teacher = _mapper.Map<Teacher>(model);

            _repo.Add(teacher);
            if (_repo.SaveChanges())
            {
                return Created($"/api/teacher/{model.Id}", _mapper.Map<TeacherDto>(teacher));
            }
            return BadRequest("Unregistered teacher");
        }

        // api/teacher
        [HttpPut("{id}")]
        public IActionResult Put(int id, TeacherRegisterDto model)
        {
            var teacher = _repo.GetTeacherById(id, false);
            if (teacher == null)
            {
                return BadRequest("Teacher not found");
            }

            _mapper.Map(model, teacher);

            _repo.Update(teacher);
            if (_repo.SaveChanges())
            {
                return Created($"/api/teacher/{model.Id}", _mapper.Map<TeacherDto>(teacher));
            }
            return BadRequest("Non-updated teacher");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, TeacherRegisterDto model)
        {
            var teacher = _repo.GetTeacherById(id, false);
            if (teacher == null)
            {
                return BadRequest("Teacher not found");
            }

            _mapper.Map(model, teacher);
            
            _repo.Update(teacher);
            if (_repo.SaveChanges())
            {
                return Created($"/api/teacher/{model.Id}", _mapper.Map<TeacherDto>(teacher));
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