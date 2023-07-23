using AutoMapper;
using DemoAPIApp.Data.Model;
using DemoAPIApp.Services.AcademicYearService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicYearController : ControllerBase
    {
        private readonly IAcademicYearService _academicYearService;
        private readonly IMapper _mapper;
        public AcademicYearController(IAcademicYearService academicYearService, IMapper mapper) 
        {

            _academicYearService = academicYearService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAcademicYear()
        {
            var academicYear = await _academicYearService.GetAcademicYears();
            return Ok(academicYear);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAcademicYearById(int id)
        {
            
            var academicYear = await _academicYearService.GetAcademicYearById(id);

            return Ok(academicYear);
        }

        [HttpPost]
        public async Task<IActionResult> AddAcademicYear(AcademicYear academicYear)
        {
            var academicYearAdd = await _academicYearService.AddAcademicYear(academicYear);
            return Ok(academicYearAdd);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAcademicYear(int id, AcademicYear academicYear)
        {
            var academicYearUpdate = await _academicYearService.UpdateAcademicYear(id, academicYear);
            return Ok(academicYearUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicYear(int id)
        {
            var academicYear = await _academicYearService.DeleteAcademicYear(id);

            return Ok(academicYear);
        }

        [HttpGet("{id}/class")]
        public async Task<IActionResult> GetClassByAcademicYear(int id)
        {
            var getClass = await _academicYearService.GetClassByAcademicYear(id);

            //var getClassDto = _mapper.Map<List<Class>>(getClass);

            return Ok(getClass);
        }
    }
}
