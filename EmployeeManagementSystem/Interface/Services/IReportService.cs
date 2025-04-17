
namespace EmployeeManagementSystem.Interface.Services
{
    public interface IReportService
    {
        Task<string> GenerateSalaryPDFAsync(int id);
    }
}
