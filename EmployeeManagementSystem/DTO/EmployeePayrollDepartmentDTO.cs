using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.DTO
{
    public class EmployeePayrollDepartmentDTO
    {
        [Required(ErrorMessage = "Id is required.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z]{1,50}$", ErrorMessage = "First Name must be alphabetic and cannot exceed 50 characters.")]
        public string FirstName { get; set; } = "Unknown";

        [Required(ErrorMessage = "Last Name is required.")]
        [RegularExpression(@"^[a-zA-Z]{1,50}$", ErrorMessage = "Last Name must be alphabetic and cannot exceed 50 characters.")]
        public string LastName { get; set; } = "Unknown";

        [Required(ErrorMessage = "Department Name is required.")]
        [RegularExpression(@"^[a-zA-Z]{1,50}$", ErrorMessage = "Department Name must be alphabetic and cannot exceed 50 characters.")]
        public string DepartmentName { get; set; } = null!;

        [Range(0, double.MaxValue, ErrorMessage = "Base Salary must be non-negative.")]
        public decimal BaseSalary { get; set; } = 0;

        [Range(0, double.MaxValue, ErrorMessage = "Net Pay must be non-negative.")]
        public decimal NetPay { get; set; } = 0;

        public double? Bonus { get; set; }

        public double? Deductions { get; set; }
       
        public DateOnly PayDate { get; set; }


    }
}
