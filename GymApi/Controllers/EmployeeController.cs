using GymApi.Models;
using GymDb.Services.EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee newEmployee)
        {
            return Ok(await _employeeService.CreateEmployee(newEmployee));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployerById(int id)
        {
            return Ok(await _employeeService.DeleteEmployerById(id));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployees()
        {
            await _employeeService.DeleteAllEmployees();

            return Ok("Employees were successfully deleted");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            return Ok(await _employeeService.GetEmployee(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await _employeeService.GetAllEmployees());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee, int id)
        {
            return Ok(await _employeeService.UpdateEmployee(employee, id));
        }
    }
}
