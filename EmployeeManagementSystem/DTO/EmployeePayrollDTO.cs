using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.DTO
{

    public class EmployeePayrollDTO
    {
         [Required(ErrorMessage = "Employee ID is required.")]
         public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Payroll ID is required.")]
        public int PrId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z]{1,50}$", ErrorMessage = "First Name must be alphabetic and cannot exceed 50 characters.")]
        public string FirstName { get; set; } = "Unknown";

        [Required(ErrorMessage = "Last Name is required.")]
        [RegularExpression(@"^[a-zA-Z]{1,50}$", ErrorMessage = "Last Name must be alphabetic and cannot exceed 50 characters.")]
        public string LastName { get; set; } = "Unknown";

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Base Salary must be a non-negative value.")]
        public double BaseSalary { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Bonus must be a non-negative value.")]
        public double? Bonus { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Deductions must be a non-negative value.")]
        public double? Deductions { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Net Pay must be a non-negative value.")]
        public double NetPay { get; set; }

        [Required(ErrorMessage = "Pay Date is required.")]
        public DateOnly PayDate { get; set; }

          [Timestamp]
         public byte[] RowVersion { get; set; }
        }
}


