using EmployeeManagementSystem.Interface.Repositories;
using EmployeeManagementSystem.Interface.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeDepartmentPayrollController : ControllerBase
    {
        private readonly IEmployeeDepartmentPayrollService _service;
        public EmployeeDepartmentPayrollController(IEmployeeDepartmentPayrollService service) {
            _service = service;
        }

        [HttpGet("GetFinanceDepartmentEmployeewithPayroll")]
        public async Task<IActionResult> GetFinanceDepartmentEmployeesWithPayrollAsync()
        {
          var emp= await _service.GetFinanceEmployeesWithPayrollAsync();
            return Ok(emp);
        }
        [HttpGet("GetEmployeesWithDepartmentAndPayroll")]
        public async Task<IActionResult> GetEmployeesWithDepartmentAndPayroll()
        {
            var result = await _service.GetEmployeesWithDepartmentAndPayrollAsync();
            return Ok( result);
        }

        [HttpGet("CalculateBonus/{departmentId}")]
        public async Task<IActionResult> CalculateBonus(int departmentId)
        {
            var result = await _service.GetEmployeeBonusesByDepartment(departmentId);
            return Ok(result);
        }

    }
}
