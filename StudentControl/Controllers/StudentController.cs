using Microsoft.AspNetCore.Mvc;
using StudentControl.Models;
using StudentControl.Services;

namespace StudentControl.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public List<Student> GetAll()
        {
            return _studentService.GetAll();
        }

        [HttpGet("{id}")]
        public Student GetById(int id)
        {
            return _studentService.GetById(id);
        }

        [HttpPost]
        public Student Create([FromBody] Student student)
        {
            return _studentService.Create(student);
        }

        [HttpPut("{id}")]
        public Student Update(int id, [FromBody] Student student)
        {
            return _studentService.Update(id, student);
        }

        [HttpDelete("{id}")]
        public Student Delete(int id)
        {
            return _studentService.Delete(id);
        }
        
        [HttpGet("hasaprove/{id}")]
        public bool HasAproved(int id)
        {
            return _studentService.HasAproved(id);
        }
    }
}