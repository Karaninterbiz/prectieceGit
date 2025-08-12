using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinancialModule.Infrastructure.Data.Models;

[Table("DiscountPlan", Schema = "billing")]
public partial class DiscountPlan
{
    [Key]
    [Column("DiscountPlanID")]
    public Guid DiscountPlanId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Name { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Code { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? DiscountType { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? DiscountValue { get; set; }

    public bool? IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    [InverseProperty("DiscountPlan")]
    public virtual ICollection<CustomerAccountingInfo> CustomerAccountingInfos { get; set; } = new List<CustomerAccountingInfo>();
}
