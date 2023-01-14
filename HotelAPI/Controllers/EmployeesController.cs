using Core.Interfaces.Service;
using Infrastructure.Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            List<EmployeeDTO> employeeDtos = await _employeeService.GetAllEmployees(HttpContext.RequestAborted);

            return Ok(employeeDtos);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployee([FromRoute] string employeeId)
        {
            EmployeeDTO result = await _employeeService.GetEmployeeById(employeeId, HttpContext.RequestAborted);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDTO newEmployee)
        {
            int employeeId = await _employeeService.CreateEmployee(newEmployee);

            return Ok(employeeId);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] string employeeId, [FromBody] EmployeeDTO request)
        {
            EmployeeDTO updatedEmployee = await _employeeService.UpdateEmployee(employeeId, request);

            if (updatedEmployee == null)
                return BadRequest();

            return Ok(updatedEmployee);
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] string employeeId)
        {
            bool hasEmployeeBeenDeleted = await _employeeService.DeleteEmployee(employeeId);

            if (!hasEmployeeBeenDeleted)
                return NotFound();

            return NoContent();
        }
    }
}
