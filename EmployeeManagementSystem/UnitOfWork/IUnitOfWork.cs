using EmployeeManagementSystem.Interface.Repositories;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.UnitOfWorks
{
    public interface IUnitOfWork :IDisposable
    {
        IGenericRepository<Employee> Employees { get; }
        IGenericRepository<Payroll> Payrolls {  get; }

        Task SaveAsync();
    }
}
