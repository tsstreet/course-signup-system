using DemoAPIApp.Data.Model;
using DemoAPIApp.Services.ClassService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        public ClassController(IClassService classService) 
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<ActionResult<Class>> GetClasses()
        {
            var getClass = await _classService.GetClasses();
            return Ok(getClass);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetClassById(int id)
        {
            
            var getClass = await _classService.GetClassById(id);

            return Ok(getClass);
        }

        [HttpPost]
        public async Task<ActionResult<Class>> AddClass(Class falcuty)
        {
            var classAdd = await _classService.AddClass(falcuty);
            return Ok(classAdd);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Class>> UpdateClass(int id, Class classs)
        {
            var classUpdate = await _classService.UpdateClass(id, classs);
            return Ok(classUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Class>> DeleteClass(int id)
        {
            var deleteClass = await _classService.DeleteClass(id);

            return Ok(deleteClass);
        }

    }
}
