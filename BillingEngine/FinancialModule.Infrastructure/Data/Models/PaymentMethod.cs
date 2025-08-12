using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinancialModule.Infrastructure.Data.Models;

[Table("PaymentMethod", Schema = "billing")]
public partial class PaymentMethod
{
    [Key]
    [Column("PaymentMethodID")]
    public Guid PaymentMethodId { get; set; }

    [Column("CustomerAccountingInfoID")]
    public Guid? CustomerAccountingInfoId { get; set; }

    [Column("GatewayPaymentMethodID")]
    [StringLength(30)]
    [Unicode(false)]
    public string? GatewayPaymentMethodId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Name { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? MethodType { get; set; }

    public bool? IsAutopayEnabled { get; set; }

    public bool? IsDefault { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastUpdatedOn { get; set; }

    public Guid? LastUpdatedBy { get; set; }

    [ForeignKey("CustomerAccountingInfoId")]
    [InverseProperty("PaymentMethods")]
    public virtual CustomerAccountingInfo? CustomerAccountingInfo { get; set; }
}
