using EmployeeManagementSystem.DTO;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interface.Repositories
{
    public interface IEmployeeDepartmentPayrollRepository
    {
        public Task<IEnumerable<EmployeePayrollDepartmentDTO>> GetFinanceEmployeesWithPayrollAsync();
        public Task<List<EmployeePayrollDepartmentDTO>> GetEmployeesWithDepartmentAndPayrollAsync();

        public Task<EmployeePayrollDTO> GetEmployeeDetailWithPayroll(int id);

        //Question 20
        public Task<List<EmployeePayrollDepartmentDTO>> GetEmployeeBonusesByDepartment(int departmentId);

        public Task<EmployeePayrollDTO> CalculateBonusByIds(int empId);

    }
}

