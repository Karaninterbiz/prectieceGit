using EmployeeManagementSystem.DTO;

namespace EmployeeManagementSystem.Interface.Services
{
    public interface IEmployeeDepartmentPayrollService
    {
        public Task<IEnumerable<EmployeePayrollDepartmentDTO>> GetFinanceEmployeesWithPayrollAsync();

        public Task<List<EmployeePayrollDepartmentDTO>> GetEmployeesWithDepartmentAndPayrollAsync();
        public Task<EmployeePayrollDTO> GetEmployeeDetailWithPayroll(int id);
        public Task<EmployeePayrollDTO?> CalculateBonusById(int id);

        public Task<List<EmployeePayrollDepartmentDTO>> GetEmployeeBonusesByDepartment(int departmentId);

    }
}
