using EmployeeManagementSystem.DTO;
using EmployeeManagementSystem.Interface.Repositories;
using EmployeeManagementSystem.Interface.Services;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services.Implementation
{
    public class EmployeeDepartmentPayrollService : IEmployeeDepartmentPayrollService
    {
        private readonly IEmployeeDepartmentPayrollRepository _repository;
        public EmployeeDepartmentPayrollService(IEmployeeDepartmentPayrollRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EmployeePayrollDepartmentDTO>> GetEmployeesWithDepartmentAndPayrollAsync()
        {
            var emp = await _repository.GetEmployeesWithDepartmentAndPayrollAsync();
            return emp;
        }

        public async Task<IEnumerable<EmployeePayrollDepartmentDTO>> GetFinanceEmployeesWithPayrollAsync()
        {
            return await _repository.GetFinanceEmployeesWithPayrollAsync();
        }

        public async Task<EmployeePayrollDTO> GetEmployeeDetailWithPayroll(int id)
        {
            return await _repository.GetEmployeeDetailWithPayroll(id);
        }

        public Task<EmployeePayrollDTO?> CalculateBonusById(int id)
        {
            return _repository.CalculateBonusByIds(id);
        }

        public async Task<List<EmployeePayrollDepartmentDTO>> GetEmployeeBonusesByDepartment(int departmentId)
        {
            return await _repository.GetEmployeeBonusesByDepartment(departmentId);
        }
    }
}
