using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinancialModule.Infrastructure.Data.Models;

[Table("CustomerAccountingInfo", Schema = "billing")]
public partial class CustomerAccountingInfo
{
    [Key]
    [Column("CustomerAccountingInfoID")]
    public Guid CustomerAccountingInfoId { get; set; }

    [Column("BusinessUnitID")]
    public Guid? BusinessUnitId { get; set; }

    [Column("BillingPlanID")]
    public Guid? BillingPlanId { get; set; }

    [Column("DiscountPlanID")]
    public Guid? DiscountPlanId { get; set; }

    [Column("BillingAddressID")]
    public Guid? BillingAddressId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? AccountStatus { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? OutstandingBalance { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? OverdueBalance { get; set; }

    public string? GatewayDetails { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastUpdatedOn { get; set; }

    public Guid? LastUpdatedBy { get; set; }

    [ForeignKey("BillingPlanId")]
    [InverseProperty("CustomerAccountingInfos")]
    public virtual BillingPlan? BillingPlan { get; set; }

    [ForeignKey("BusinessUnitId")]
    [InverseProperty("CustomerAccountingInfos")]
    public virtual BusinessUnit? BusinessUnit { get; set; }

    [ForeignKey("DiscountPlanId")]
    [InverseProperty("CustomerAccountingInfos")]
    public virtual DiscountPlan? DiscountPlan { get; set; }

    [InverseProperty("CustomerAccountingInfo")]
    public virtual ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();

    [InverseProperty("CustomerAccountingInfo")]
    public virtual ICollection<UsageRecord> UsageRecords { get; set; } = new List<UsageRecord>();
}
