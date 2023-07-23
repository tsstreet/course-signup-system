using DemoAPIApp.Data.Model;
using DemoAPIApp.Services.TeacherService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController (ITeacherService teacherService) 
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeacher()
        {
            var teacher = await _teacherService.GetTeachers();
            return Ok(teacher);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            
            var teacher = await _teacherService.GetTeacherById(id);

            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher(Teacher teacher)
        {
            var teacherAdd = await _teacherService.AddTeacher(teacher);
            return Ok(teacherAdd);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, Teacher teacher)
        {
            var teacherUpdate = await _teacherService.UpdateTeacher(id, teacher);
            return Ok(teacherUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStuden(int id)
        {
            var teacher = await _teacherService.DeleteTeacher(id);

            return Ok(teacher);
        }

    }
}
