using EmployeeManagementSystem.DTO;
using EmployeeManagementSystem.Interface.Repositories;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository.Implementation
{

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeemanagementContext _context;
        public EmployeeRepository(EmployeemanagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> FetchEmployeeHireInPastSixMonthAsync()
        {
            var sixMonthsAgo = DateOnly.FromDateTime(DateTime.Today.AddMonths(-6));

            return  await _context.Employees
                           .AsNoTracking()
                           .Where(e => e.HireDate >= sixMonthsAgo)
                           .OrderBy(e => e.HireDate)
                            .ToListAsync();
        }
    }
}
