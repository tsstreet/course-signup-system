using DemoAPIApp.Data.Model;
using DemoAPIApp.Services.StudentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController (IStudentService studentService) 
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudent()
        {
            var student = await _studentService.GetStudents();
            return Ok(student);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            
            var student = await _studentService.GetStudentById(id);

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            var studentAdd = await _studentService.AddStudent(student);
            return Ok(studentAdd);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student student)
        {
            var studentUpdate = await _studentService.UpdateStudent(id, student);
            return Ok(studentUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _studentService.DeleteStudent(id);

            return Ok(student);
        }

    }
}
