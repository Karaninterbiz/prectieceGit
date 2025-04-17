using EmployeeManagementSystem.DTO;


namespace EmployeeManagementSystem.Interface.Services
{
    public interface IEmployeeService
    {

        public Task AddEmployeeAsync(EmployeeDTO employeeDTO);

        public Task<IEnumerable<EmployeeDTO>> GetAllEmployeeAsync();

        public Task<EmployeeDTO> GetEmployeeByIdAsync(int id);

        public Task<EmployeeDTO> UpdateEmployeeAsync(int id, EmployeeDTO employeeDTO);

        public Task DeleteEmployeeByIdAsync(int id);

        public Task<IEnumerable<EmployeeDTO>> FetchEmployeesHiredInPastSixMonthsAsync();
    }
}
