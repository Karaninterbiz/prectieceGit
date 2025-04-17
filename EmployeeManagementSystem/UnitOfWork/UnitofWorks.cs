using EmployeeManagementSystem.Interface.Repositories;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.Implementation;
using EmployeeManagementSystem.UnitOfWorks;

public class UnitofWorks : IUnitOfWork
{
    private readonly EmployeemanagementContext _context;

    public IGenericRepository<Employee> Employees { get; }
    public IGenericRepository<Department> Departments { get; }
    public IGenericRepository<Role> Roles { get; }
    public IGenericRepository<Payroll> Payrolls { get; }

    public UnitofWorks(EmployeemanagementContext context)
    {
        _context = context;
        Employees = new GenericRepository<Employee>(_context);
        Departments = new GenericRepository<Department>(_context);
        Roles = new GenericRepository<Role>(_context);
        Payrolls=new GenericRepository<Payroll>(_context);   
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
