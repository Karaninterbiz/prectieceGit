using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Interface.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> FetchEmployeeHireInPastSixMonthAsync();
    }
}
