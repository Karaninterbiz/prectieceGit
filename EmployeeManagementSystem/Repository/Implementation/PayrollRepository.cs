using EmployeeManagementSystem.Interface.Repositories;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository.Implementation
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly EmployeemanagementContext _context;

        public PayrollRepository(EmployeemanagementContext context)
        {
            _context = context;
        }
        // Update the payroll
        public void UpdatePayroll(Payroll payroll, byte[] rowVersion)
        {
            var existingPayroll = _context.Payrolls.Find(payroll.PrId);
            if (existingPayroll == null)
            {
                throw new Exception("Payroll record not found.");
            }

            // Ensure the rowVersion matches the one in the database
            if (existingPayroll.RowVersion != rowVersion)
            {
                throw new Exception("The payroll record has been modified by another user.");
            }

            existingPayroll.BaseSalary = payroll.BaseSalary;
            existingPayroll.Bonus = payroll.Bonus;
            existingPayroll.Deductions = payroll.Deductions;
            existingPayroll.Netpay = payroll.Netpay;

            _context.Payrolls.Update(existingPayroll);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException) // Handle the exception if occurs
            {
                throw new Exception("The payroll record has been modified by another user.");
            }
        }
    }
}
