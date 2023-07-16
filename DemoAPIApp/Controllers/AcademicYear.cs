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
        public AcademicYearController(IAcademicYearService academicYearService) 
        {

            _academicYearService = academicYearService;
        }

        [HttpGet]
        public async Task<ActionResult<AcademicYear>> GetAcademicYear()
        {
            var falcuty = await _academicYearService.GetAcademicYears();
            return Ok(falcuty);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicYear>> GetAcademicYearById(int id)
        {
            
            var falcuty = await _academicYearService.GetAcademicYearById(id);

            return Ok(falcuty);
        }

        [HttpPost]
        public async Task<ActionResult<AcademicYear>> AddAcademicYear(AcademicYear academicYear)
        {
            var academicYearAdd = await _academicYearService.AddAcademicYear(academicYear);
            return Ok(academicYearAdd);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AcademicYear>> UpdateAcademicYear(int id, AcademicYear academicYear)
        {
            var academicYearUpdate = await _academicYearService.UpdateAcademicYear(id, academicYear);
            return Ok(academicYearUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AcademicYear>> DeleteAcademicYear(int id)
        {
            var academicYear = await _academicYearService.DeleteAcademicYear(id);

            return Ok(academicYear);
        }

    }
}
