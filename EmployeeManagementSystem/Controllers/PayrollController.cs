using EmployeeManagementSystem.DTO;
using EmployeeManagementSystem.Interface.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("Payroll")]
    public class PayrollController :ControllerBase
    {
        private readonly IPayrollService _service;
        public PayrollController(IPayrollService service) { 
            _service = service;
        }

        [HttpPut("Update/{payrollId}")]
        public IActionResult UpdatePayrollSalary(int payrollId, int netPay)
        {
            try
            {
                PayrollDTO payrollDTO = _service.UpdateEmployeeSalary(payrollId, netPay);
                return Ok(payrollDTO);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message); // In case of concurrency conflicts
            }
        }
    }
}
