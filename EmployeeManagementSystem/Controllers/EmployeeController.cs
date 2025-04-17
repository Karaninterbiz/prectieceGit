using EmployeeManagementSystem.DTO;
using EmployeeManagementSystem.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            return Ok(await _employeeService.GetAllEmployeeAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var emp = await _employeeService.GetEmployeeByIdAsync(id);
            if (emp != null)
            {
                return Ok(emp);
            }
            return NotFound("Id not Found");

        }

        [HttpPost]
        public async Task<IActionResult> PostEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                await _employeeService.AddEmployeeAsync(employeeDTO);
                return Ok("Employee added successfully");
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Log unexpected error if needed
                return StatusCode(500, "An unexpected error occurred.");
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeDTO employeeDTO)
        {
            var updatedEmployee = await _employeeService.UpdateEmployeeAsync(id, employeeDTO);
            if (updatedEmployee != null)
                return Ok(updatedEmployee);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {

               await _employeeService.DeleteEmployeeByIdAsync(id);
           
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeHireInPastSixMonths()
        {
            return Ok(await _employeeService.FetchEmployeesHiredInPastSixMonthsAsync());
        }
    }
}
