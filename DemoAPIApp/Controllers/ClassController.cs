using AutoMapper;
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
        private readonly IMapper _mapper;
        public ClassController(IClassService classService, IMapper mapper) 
        {
            _classService = classService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult>GetClasses()
        {
            var getClass = await _classService.GetClasses();

            var getClassDto = _mapper.Map<List<Class>>(getClass);

            return Ok(getClassDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassById(int id)
        {       
            var getClass = await _classService.GetClassById(id);
            var getClassDto = _mapper.Map<Class>(getClass);

            return Ok(getClassDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddClass(ClassDto request)
        {
            //var classAdd = await _classService.AddClass(classDto);

            var classEntity = _mapper.Map<Class>(request);
            var classMap = await _classService.AddClass(classEntity);
            
            return Ok(classMap);
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
