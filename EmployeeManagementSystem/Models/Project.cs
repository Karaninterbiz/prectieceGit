using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Models;

public partial class Project
{
    public int PrId { get; set; }

    public string PrName { get; set; } = null!;

    public string PrStatus { get; set; } = null!;

    public DateOnly PrStartDate { get; set; }

    public DateOnly ExpectedCompletionDate { get; set; }
}
