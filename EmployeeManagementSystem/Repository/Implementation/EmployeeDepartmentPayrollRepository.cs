using EmployeeManagementSystem.DTO;
using EmployeeManagementSystem.Helpers;
using EmployeeManagementSystem.Interface.Repositories;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using QuestPDF.Helpers;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Repository.Implementation
{
    public class EmployeeDepartmentPayrollRepository : IEmployeeDepartmentPayrollRepository
    {
        private readonly EmployeemanagementContext _context;
        private readonly ILogger<EmployeeDepartmentPayrollRepository> _logger;

        public EmployeeDepartmentPayrollRepository(EmployeemanagementContext context, ILogger<EmployeeDepartmentPayrollRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

       

        public async Task<EmployeePayrollDTO?> CalculateBonusByIds(int empId)
        {
           var payroll=await _context.Payrolls.Include(p=>p.Employee)
                                               .FirstOrDefaultAsync(p=>p.EmployeeId==empId);

            if (payroll == null) {
                return null;
            }
            var calc = new CalculateSalary();

            var employeeData = new EmployeePayrollDTO
            {
                EmployeeId = payroll.Employee.Eid,
                FirstName = payroll.Employee.FirstName,
                LastName = payroll.Employee.LastName,
                PrId = payroll.PrId,
                BaseSalary = payroll.BaseSalary,
                Bonus = payroll.Bonus ?? 0,
                Deductions = payroll.Deductions ?? 0,
                NetPay = payroll.Netpay,
                PayDate = payroll.PayDate,
            };

            foreach (var entry in _context.ChangeTracker.Entries())
            {
                Console.WriteLine($"\nEntity: {entry.Entity.GetType().Name}, State: {entry.State}");
            }
            return employeeData;
        }


        public async  Task<EmployeePayrollDTO> GetEmployeeDetailWithPayroll(int id)
        {
            var emp = await _context.Employees
                           .AsTracking()
                           .Include(e => e.Payrolls)
                           .FirstOrDefaultAsync(e => e.Eid == id);

            if (emp == null)
            {
                throw new KeyNotFoundException("Employee not found.");
            }

            if (emp.Payrolls == null || !emp.Payrolls.Any())
            {
                throw new InvalidOperationException("Payroll data not found for the employee.");
            }

            var payroll = emp.Payrolls.OrderByDescending(p => p.PayDate).FirstOrDefault();

            var dto = new EmployeePayrollDTO
            {
                EmployeeId = emp.Eid,
                PrId = payroll.PrId,
                FirstName = emp.FirstName,
                LastName = emp.LastName ?? "Unknown",
                BaseSalary = payroll.BaseSalary,
                Bonus = payroll.Bonus ?? 0,
                Deductions = payroll.Deductions ?? 0,
                NetPay = payroll.Netpay,
                PayDate = payroll.PayDate
            };

            return dto;
        }

        public async Task<List<EmployeePayrollDepartmentDTO>> GetEmployeesWithDepartmentAndPayrollAsync()
        {

            var emp = await _context.Employees.Include(e => e.Department).Include(e => e.Payrolls).AsNoTracking().
                Select(x => new EmployeePayrollDepartmentDTO
                {
                    EmployeeId = x.Eid,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DepartmentName = x.Department.DepName,
                    BaseSalary = (decimal)x.Payrolls
                            .OrderByDescending(p => p.PayDate)
                            .Select(p => p.BaseSalary)
                            .FirstOrDefault(),
                    NetPay = (decimal)x.Payrolls.OrderByDescending(p => p.PayDate)
                      .Select(p => p.Netpay)
                       .FirstOrDefault(),
                    Bonus = x.Payrolls.OrderByDescending(p => p.PayDate).Select(p=>p.Bonus).FirstOrDefault(),
                    Deductions=x.Payrolls.OrderByDescending(p => p.PayDate).Select(p => p.Deductions).FirstOrDefault(),
                    PayDate=x.Payrolls.OrderByDescending(p => p.PayDate).Select(p => p.PayDate).FirstOrDefault(),
                }).ToListAsync();
                return emp;
            
        }

        public async Task<IEnumerable<EmployeePayrollDepartmentDTO>> GetFinanceEmployeesWithPayrollAsync()
        {
            var employees = await _context.Employees
          .Include(e => e.Payrolls)
          .Include(e => e.Department)
          .Where(e => e.Department != null && e.Department.DepName.ToUpper() == "FINANCE")
          .AsNoTracking()
          .Select(empDEpPay => new EmployeePayrollDepartmentDTO
           {
               EmployeeId = empDEpPay.Eid,
               FirstName = empDEpPay.FirstName,
               LastName = empDEpPay.LastName,
               DepartmentName = empDEpPay.Department != null ? empDEpPay.Department.DepName : "Not Found",
               BaseSalary = (decimal)empDEpPay.Payrolls
                            .OrderByDescending(p => p.PayDate)
                            .Select(p => p.BaseSalary)
                            .FirstOrDefault(),
               NetPay=(decimal)empDEpPay.Payrolls.OrderByDescending(p=>p.PayDate)
                       .Select(p=>p.Netpay)
                       .FirstOrDefault()
           })
          .ToListAsync();

           return employees;
        }

        public EmployeePayrollDTO UpdateEmployeeSalaryAndPayroll(int employeeId, double newSalary)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeePayrollDTO> UpdatePayrollSalaryWithConcurrencyAsync(EmployeePayrollDTO payrollDto)
        {
            var existingPayroll = await _context.Payrolls
                .FirstOrDefaultAsync(p => p.PrId == payrollDto.PrId);

            if (existingPayroll == null)
                throw new Exception("Payroll record not found.");

            // Set original RowVersion for concurrency check
            _context.Entry(existingPayroll).Property("RowVersion").OriginalValue = payrollDto.RowVersion;

            // Update fields
            existingPayroll.BaseSalary = payrollDto.BaseSalary;
            existingPayroll.Netpay = (payrollDto.BaseSalary + (existingPayroll.Bonus ?? 0)) - (existingPayroll.Deductions ?? 0);
            existingPayroll.PayDate = DateOnly.FromDateTime(DateTime.Now);

            try
            {
                await _context.SaveChangesAsync();

                // Return updated DTO
                return new EmployeePayrollDTO
                {
                    EmployeeId = existingPayroll.EmployeeId,
                    PrId = existingPayroll.PrId,
                    BaseSalary = existingPayroll.BaseSalary,
                    Bonus = existingPayroll.Bonus,
                    Deductions = existingPayroll.Deductions,
                    NetPay = existingPayroll.Netpay,
                    PayDate = existingPayroll.PayDate,
                    RowVersion = existingPayroll.RowVersion
                };
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("Concurrency conflict detected. The record has been modified by another user.");
            }
        }


        async Task<List<EmployeePayrollDepartmentDTO>> IEmployeeDepartmentPayrollRepository.GetEmployeeBonusesByDepartment(int departmentId)
        {
            var result = new List<EmployeePayrollDepartmentDTO>();
            var connection = _context.Database.GetDbConnection();
            await using var command= connection.CreateCommand();
            command.CommandText = "CALL CalculateAndDisplayEmployeeBonus(@deptId)";
            command.CommandType=System.Data.CommandType.Text;
            var param=command.CreateParameter();
            param.ParameterName = "@deptId";
            param.Value = departmentId;
            command.Parameters.Add(param);

            await connection.OpenAsync();

            using var reader=await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new EmployeePayrollDepartmentDTO
                {

                    EmployeeId = reader.GetInt32(reader.GetOrdinal("EmployeeId")),
                    //PrId = reader.GetInt32(reader.GetOrdinal("PrId")),
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                    BaseSalary = (decimal)reader.GetDouble(reader.GetOrdinal("BaseSalary")),
                    Bonus = reader.IsDBNull(reader.GetOrdinal("Bonus")) ? null : reader.GetDouble(reader.GetOrdinal("Bonus")),
                    Deductions = reader.IsDBNull(reader.GetOrdinal("Deductions")) ? null : reader.GetDouble(reader.GetOrdinal("Deductions")),
                    NetPay = (decimal)reader.GetDouble(reader.GetOrdinal("Netpay")),
                    PayDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("PayDate"))),

                });
            }

            await connection.CloseAsync();
            return result;

        }
    }
}
