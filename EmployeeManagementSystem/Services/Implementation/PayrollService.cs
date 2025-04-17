using EmployeeManagementSystem.DTO;
using EmployeeManagementSystem.Interface.Repositories;
using EmployeeManagementSystem.Interface.Services;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.UnitOfWorks;

namespace EmployeeManagementSystem.Services.Implementation
{
    public class PayrollService :IPayrollService

    {
        private readonly IPayrollRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public PayrollService(IPayrollRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public PayrollDTO UpdateEmployeeSalary(int payrollId, double newSalary)
        {
            var payroll = _unitOfWork.Payrolls.FindByIdAsync(payrollId).Result;

            if (payroll == null)
                throw new Exception("Payroll record not found.");

            DateTime currentTime = DateTime.Now;

            byte[] rowVersionBytes = BitConverter.GetBytes(currentTime.Ticks);      // Convert the date time to byte format of row version

            // Update payroll
            payroll.BaseSalary = newSalary;

            // Update the payroll with the RowVersion for concurrency checking
            _unitOfWork.Payrolls.Update(payroll, payrollId);

            _unitOfWork.SaveAsync();

            return new PayrollDTO           // Return Payroll DTO
            {
                PrId = payroll.PrId,
                BaseSalary = payroll.BaseSalary,
                Bonus = payroll.Bonus,
                Deductions = payroll.Deductions,
                Netpay = payroll.Netpay,
                PayDate = payroll.PayDate,
                RowVersion = payroll.RowVersion
            };
        }
    }
}
