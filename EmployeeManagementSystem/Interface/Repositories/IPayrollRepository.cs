using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interface.Repositories
{
    public interface IPayrollRepository
    {
        void UpdatePayroll(Payroll payroll, byte[] rowVersion);
    }
}
