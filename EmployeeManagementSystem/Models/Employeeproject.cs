using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Models;

public partial class Employeeproject
{
    public int? EmployeeId { get; set; }

    public int? ProjectId { get; set; }

    public int? RoleId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Project? Project { get; set; }

    public virtual Role? Role { get; set; }
}
