using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinancialModule.Infrastructure.Data.Models;

[Table("UsageRecord", Schema = "billing")]
public partial class UsageRecord
{
    [Key]
    [Column("UsageID")]
    public Guid UsageId { get; set; }

    [Column("CustomerAccountingInfoID")]
    public Guid? CustomerAccountingInfoId { get; set; }

    [Column("InvoiceID")]
    public Guid? InvoiceId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UsageDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UsageType { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? Quantity { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? UnitPrice { get; set; }

    [Column(TypeName = "decimal(29, 6)")]
    public decimal? TotalCost { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    [ForeignKey("CustomerAccountingInfoId")]
    [InverseProperty("UsageRecords")]
    public virtual CustomerAccountingInfo? CustomerAccountingInfo { get; set; }

    [ForeignKey("InvoiceId")]
    [InverseProperty("UsageRecords")]
    public virtual Invoice? Invoice { get; set; }
}
