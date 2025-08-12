using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinancialModule.Infrastructure.Data.Models;

[Table("Invoice", Schema = "billing")]
public partial class Invoice
{
    [Key]
    [Column("InvoiceID")]
    public Guid InvoiceId { get; set; }

    [Column("BusinessUnitID")]
    public Guid? BusinessUnitId { get; set; }

    [Column("GatewayInvoiceID")]
    [StringLength(100)]
    [Unicode(false)]
    public string? GatewayInvoiceId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? SubTotal { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? TaxAmount { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? TotalAmount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PaymentDate { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? RefundAmount { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? InvoiceStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InvoiceDueDate { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [Column("BillingPlanID")]
    public Guid? BillingPlanId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? BillingPeriod { get; set; }

    public int? BillingPeriodNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? GeneratedDateTime { get; set; }

    [ForeignKey("BillingPlanId")]
    [InverseProperty("Invoices")]
    public virtual BillingPlan? BillingPlan { get; set; }

    [ForeignKey("BusinessUnitId")]
    [InverseProperty("Invoices")]
    public virtual BusinessUnit? BusinessUnit { get; set; }

    [InverseProperty("Invoice")]
    public virtual ICollection<UsageRecord> UsageRecords { get; set; } = new List<UsageRecord>();
}
