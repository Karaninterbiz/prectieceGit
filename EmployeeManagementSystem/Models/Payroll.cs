using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models;

public partial class Payroll
{
    public int PrId { get; set; }

    public double BaseSalary { get; set; }

    public double? Bonus { get; set; }

    public double? Deductions { get; set; }

    public double Netpay { get; set; }

    public DateOnly PayDate { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    [Timestamp]
    public byte[] RowVersion { get; set; }
}
