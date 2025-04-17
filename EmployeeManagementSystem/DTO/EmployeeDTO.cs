using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.DTO
{
    public class EmployeeDTO
    {
        [Required(ErrorMessage="Employee ID is required.")]
        public int Eid {get; set; }

        [Required(ErrorMessage="FirstName is Required . ")]
        [StringLength(50, ErrorMessage = "First Name can't exceed 50 characters.")]
        public string? FirstName { get; set; }

        [StringLength(50,ErrorMessage ="Last Name can't exceed 50 characters. ")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Hire date is required.")]
        public DateOnly HireDate { get; set; }

        [Required(ErrorMessage = "Department ID is required.")]
        [Range(1, 1000, ErrorMessage = "DepartmentId must be between 100 and 1000.")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Role ID is required.")]
        [Range(1, 1000, ErrorMessage = "RoleId must be between 100 and 1000.")]
        public int RoleId { get; set; }

        [Range(1, 5, ErrorMessage = "Performance rating must be between 1 and 5.")]
        public int PerformanceRating { get; set; }
    }
}
