using EmployeeManagementSystem.Helpers;
using EmployeeManagementSystem.Interface.Repositories;
using EmployeeManagementSystem.Interface.Services;
using EmployeeManagementSystem.Repository.Implementation;
using QuestPDF.Fluent;

namespace EmployeeManagementSystem.Services.Implementation
{
    public class ReportService : IReportService
    {
        private readonly IEmployeeDepartmentPayrollRepository _repository;
        public ReportService(EmployeeDepartmentPayrollRepository repository) { 
            _repository = repository;
        }
        public async Task<string> GenerateSalaryPDFAsync(int id)
        {
           var emp= await _repository.GetEmployeeDetailWithPayroll(id);
            if (emp == null) {
                throw new Exception("Employee Payroll data not found");
            }

            //file name and path setup
            var fileName = $"Employee_{emp.EmployeeId}_Payroll_{DateTime.Now.Ticks}.pdf";
            var folderpath=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","Reports");
            Directory.CreateDirectory(folderpath);
            var filePath=Path.Combine(folderpath,fileName);

            //create pdf document
            var document=new EmployeePayrollPdfDocument(emp);
            document.GeneratePdf(filePath);

            // Return relative path to access from frontend or Swagger
            return $"/reports/{fileName}";
        }
    }
}
