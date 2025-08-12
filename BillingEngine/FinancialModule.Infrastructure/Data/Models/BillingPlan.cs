using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinancialModule.Infrastructure.Data.Models;

[Table("BillingPlan", Schema = "billing")]
public partial class BillingPlan
{
    [Key]
    [Column("BillingPlanID")]
    public Guid BillingPlanId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? BaseFee { get; set; }

    public bool? IsActive { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? ProviderToSupplierOrderCost { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? SupplierToSupplierOrderCost { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? ExchangeRateOrderCost { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? CaptiveOrderCost { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    [InverseProperty("BillingPlan")]
    public virtual ICollection<CustomerAccountingInfo> CustomerAccountingInfos { get; set; } = new List<CustomerAccountingInfo>();

    [InverseProperty("BillingPlan")]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
