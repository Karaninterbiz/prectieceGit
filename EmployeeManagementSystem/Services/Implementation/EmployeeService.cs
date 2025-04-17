using EmployeeManagementSystem.DTO;
using EmployeeManagementSystem.Interface.Repositories;
using EmployeeManagementSystem.Interface.Services;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.UnitOfWorks;

namespace EmployeeManagementSystem.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employee;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IGenericRepository<Employee> _employeeRepository;
        public EmployeeService(IGenericRepository<Employee> employeeRepository, IEmployeeRepository employee, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _employee = employee;
            _unitOfWork = unitOfWork;
        }

        public async Task AddEmployeeAsync(EmployeeDTO employeeDTO)
        {
            if (employeeDTO.Eid < 0)
            {
                throw new ApplicationException("Employee ID must be a positive number.");
            }
            var emp = new Employee
            {
                Eid = employeeDTO.Eid,
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                HireDate = employeeDTO.HireDate,
                DepartmentId = employeeDTO.DepartmentId,
                RoleId = employeeDTO.RoleId,
                PerformanceRating = employeeDTO.PerformanceRating
            };

            await _unitOfWork.Employees.AddAsync(emp);
        }

        public async Task DeleteEmployeeByIdAsync(int id)
        {
            var emp = await _employeeRepository.FindByIdAsync(id);
            if (emp != null)
            {
                await _unitOfWork.Employees.DeleteAsync(emp);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<IEnumerable<EmployeeDTO>> FetchEmployeesHiredInPastSixMonthsAsync()
        {
            var employees = await _employee.FetchEmployeeHireInPastSixMonthAsync();
            return employees.Select(e => new EmployeeDTO
            {
                Eid = e.Eid,
                FirstName = e.FirstName,
                LastName = e.LastName,
                HireDate = e.HireDate,
                DepartmentId = e.DepartmentId,
                RoleId = e.RoleId
            });
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeeAsync()
        {
            var employees=await _unitOfWork.Employees.GetAllAsync();
        
            return employees.Select(e => new EmployeeDTO
            {
                Eid = e.Eid,
                FirstName = e.FirstName,
                LastName = e.LastName,
                HireDate = e.HireDate,
                DepartmentId = e.DepartmentId,
                RoleId = e.RoleId
            });
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            var emp = await _unitOfWork.Employees.FindByIdAsync(id);
            if (emp == null)
                return null;
            return new EmployeeDTO
            {
                Eid = emp.Eid,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                HireDate = emp.HireDate,
                DepartmentId = emp.DepartmentId,
                RoleId = emp.RoleId
            };
        }

        public async Task<EmployeeDTO> UpdateEmployeeAsync(int id, EmployeeDTO employeeDTO)
        {
            // Fetch existing employee
            var existEmployee = await _unitOfWork.Employees.FindByIdAsync(id);
            if (existEmployee == null)
                throw new Exception("Employee not found.");

            // Update fields
            existEmployee.FirstName = employeeDTO.FirstName;
            existEmployee.LastName = employeeDTO.LastName;
            existEmployee.HireDate = employeeDTO.HireDate;
            existEmployee.DepartmentId = employeeDTO.DepartmentId;
            existEmployee.RoleId = employeeDTO.RoleId;
            existEmployee.PerformanceRating = employeeDTO.PerformanceRating;

            // Save updated entity
            var updatedEmp = await _unitOfWork.Employees.UpdateAsync(existEmployee);

            // Return DTO
            return new EmployeeDTO
            {
                Eid = updatedEmp.Eid,
                FirstName = updatedEmp.FirstName,
                LastName = updatedEmp.LastName,
                HireDate = updatedEmp.HireDate,
                DepartmentId = updatedEmp.DepartmentId,
                RoleId = updatedEmp.RoleId,
                PerformanceRating = updatedEmp.PerformanceRating ?? 0

            };
        }

    }
}
