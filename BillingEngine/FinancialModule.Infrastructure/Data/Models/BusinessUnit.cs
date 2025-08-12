using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinancialModule.Infrastructure.Data.Models;

[Table("BusinessUnit", Schema = "billing")]
public partial class BusinessUnit
{
    [Key]
    [Column("BusinessUnitID")]
    public Guid BusinessUnitId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? BusinessType { get; set; }

    public bool? OpenNonContractedProvider { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsSystemPartner { get; set; }

    public bool? IsGlobal { get; set; }

    public double? MaxCapacity { get; set; }

    public bool? IsAutoCollect { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? BusinessTypeName { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? LocationType { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? ZipOrPostalCode { get; set; }

    [Column("ParentBusinessUnitID")]
    public Guid? ParentBusinessUnitId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Website { get; set; }

    [Column("RelatedGlobalBusinessUnitID")]
    public Guid? RelatedGlobalBusinessUnitId { get; set; }

    public Guid? AddedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastUpdatedOn { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? LastUpdatedBy { get; set; }

    [InverseProperty("BusinessUnit")]
    public virtual ICollection<CustomerAccountingInfo> CustomerAccountingInfos { get; set; } = new List<CustomerAccountingInfo>();

    [InverseProperty("BusinessUnit")]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
