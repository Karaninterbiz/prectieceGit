using EmployeeManagementSystem.DTO;
using EmployeeManagementSystem.Helpers;
using EmployeeManagementSystem.Interface.Repositories;
using EmployeeManagementSystem.Interface.Services;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Service.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using System.Transactions;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmployeePayrollController:ControllerBase
    {
        private readonly IEmployeeDepartmentPayrollService _service;
        public EmployeePayrollController(IEmployeeDepartmentPayrollService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeesWithPayroll(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Employee ID.");
            }
            var emp = await _service.GetEmployeeDetailWithPayroll(id);
            return Ok(emp);
        }

        [HttpGet("report/{id}")]
        public async Task<IActionResult> GenerateEmployeePayrollPdf(int id)
        {
            if (id <= 0 )
                return BadRequest("Invalid Employee ID.");

            var dto = await _service.GetEmployeeDetailWithPayroll(id);
            if (dto == null)
                return NotFound("Employee not found or no payroll data.");

            // Define wwwroot/reports folder
            var wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var reportsFolder = Path.Combine(wwwRootPath, "reports");

            if (!Directory.Exists(reportsFolder))
                Directory.CreateDirectory(reportsFolder);

            var fileName = $"Employee_Payroll_{dto.EmployeeId}.pdf";
            var filePath = Path.Combine(reportsFolder, fileName);

            // Generate the PDF
            var document = new EmployeePayrollPdfDocument(dto);
            document.GeneratePdf(filePath);

            // Generate URL to be returned in JSON
            var pdfUrl = $"{Request.Scheme}://{Request.Host}/reports/{fileName}";

            // Return JSON with URL
            return Ok(new
            {
                message = "PDF generated successfully",
                pdfUrl = pdfUrl,
                employee = dto
            });
        }

        [HttpGet("report/download/{id}")]
        public async Task<IActionResult> DownloadEmployeePayrollPdf(int id)
        {
            var dto = await _service.GetEmployeeDetailWithPayroll(id);
            if (dto == null)
                return NotFound("Employee not found.");

            var document = new EmployeePayrollPdfDocument(dto);
            var stream = new MemoryStream();
            document.GeneratePdf(stream);
            stream.Position = 0;

            var fileName = $"Employee_Payroll_{dto.EmployeeId}.pdf";
            return File(stream, "application/pdf", fileName); // Triggers download
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CalculateEmployeeBonuses(int id)
        {
            var employeeData = await _service.CalculateBonusById(id);

            if (employeeData == null)
            {
                return BadRequest("There is night something wrong or Employee Payroll doesn't exist");
            }

            return Ok(employeeData);
        }
    }
}
