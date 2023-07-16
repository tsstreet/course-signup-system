using DemoAPIApp.Data.Model;
using DemoAPIApp.Services.DepartmentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService) 
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<Department>> GetDepartment()
        {
            var department = await _departmentService.GetDepartments();
            return Ok(department);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            
            var department = await _departmentService.GetDepartmentById(id);

            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult<Department>> AddDepartment(Department department)
        {
            var departmentAdd = await _departmentService.AddDepartment(department);
            return Ok(departmentAdd);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Department>> UpdateDepartment(int id, Department department)
        {
            var departmentUpdate = await _departmentService.UpdateDepartment(id, department);
            return Ok(departmentUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> DeleteDepartment(int id)
        {
            var department = await _departmentService.DeleteDepartment(id);

            return Ok(department);
        }

    }
}
