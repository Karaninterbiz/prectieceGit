using EmployeeManagementSystem.DTO;

namespace EmployeeManagementSystem.Interface.Services
{
    public interface IPayrollService
    {
        PayrollDTO UpdateEmployeeSalary(int payrollId, double newSalary);
    }
}
