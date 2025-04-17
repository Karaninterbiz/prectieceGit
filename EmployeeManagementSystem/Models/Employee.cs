using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models;

public partial class Employee
{
    public int Eid { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public DateOnly HireDate { get; set; }

    public int DepartmentId { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();

    public virtual Role Role { get; set; } = null!;


    public int? PerformanceRating { get; set; }

    public virtual ICollection<PerformanceReview> PerformanceReviews { get; set; } = new List<PerformanceReview>();
}
