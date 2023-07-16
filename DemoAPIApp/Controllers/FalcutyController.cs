using DemoAPIApp.Data.Model;
using DemoAPIApp.Services.FalcutyService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FalcutyController : ControllerBase
    {
        private readonly IFalcutyService _falcutyService;
        public FalcutyController(IFalcutyService falcutyService) 
        {
            _falcutyService = falcutyService;
        }

        [HttpGet]
        public async Task<ActionResult<Falcuty>> GetFalcuty()
        {
            var falcuty = await _falcutyService.GetFalcuties();
            return Ok(falcuty);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Falcuty>> GetFalcutyById(int id)
        {
            
            var falcuty = await _falcutyService.GetFalcutyById(id);

            return Ok(falcuty);
        }

        [HttpPost]
        public async Task<ActionResult<Falcuty>> AddFalcuty(Falcuty falcuty)
        {
            var falcutyAdd = await _falcutyService.AddFalcuty(falcuty);
            return Ok(falcutyAdd);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Falcuty>> UpdateFalcuty(int id, Falcuty falcuty)
        {
            var falcutyUpdate = await _falcutyService.UpdateFalcuty(id, falcuty);
            return Ok(falcutyUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Falcuty>> DeleteFalcuty(int id)
        {
            var falcuty = await _falcutyService.DeleteFalcuty(id);

            return Ok(falcuty);
        }

    }
}
