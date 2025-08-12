using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FinancialModule.Infrastructure.Data.Models;

public partial class FinancialDbContext : DbContext
{
    public FinancialDbContext()
    {
    }

    public FinancialDbContext(DbContextOptions<FinancialDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BillingPlan> BillingPlans { get; set; }

    public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }

    public virtual DbSet<CustomerAccountingInfo> CustomerAccountingInfos { get; set; }

    public virtual DbSet<DiscountPlan> DiscountPlans { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<UsageRecord> UsageRecords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-MRKKH64;Database=stripefinancialdb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BillingPlan>(entity =>
        {
            entity.HasKey(e => e.BillingPlanId).HasName("PK__BillingP__86FCD5B9660E3765");

            entity.Property(e => e.BillingPlanId).ValueGeneratedNever();
        });

        modelBuilder.Entity<BusinessUnit>(entity =>
        {
            entity.HasKey(e => e.BusinessUnitId).HasName("PK__Business__19FA597D17AFC101");

            entity.Property(e => e.BusinessUnitId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerAccountingInfo>(entity =>
        {
            entity.HasKey(e => e.CustomerAccountingInfoId).HasName("PK__Customer__ED63487ED4F76BF0");

            entity.Property(e => e.CustomerAccountingInfoId).ValueGeneratedNever();

            entity.HasOne(d => d.BillingPlan).WithMany(p => p.CustomerAccountingInfos).HasConstraintName("FK__CustomerA__Billi__403A8C7D");

            entity.HasOne(d => d.BusinessUnit).WithMany(p => p.CustomerAccountingInfos).HasConstraintName("FK__CustomerA__Busin__3F466844");

            entity.HasOne(d => d.DiscountPlan).WithMany(p => p.CustomerAccountingInfos).HasConstraintName("FK__CustomerA__Disco__412EB0B6");
        });

        modelBuilder.Entity<DiscountPlan>(entity =>
        {
            entity.HasKey(e => e.DiscountPlanId).HasName("PK__Discount__FEBB95F23AEC536C");

            entity.Property(e => e.DiscountPlanId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Invoice__D796AAD5FFFE9A5A");

            entity.Property(e => e.InvoiceId).ValueGeneratedNever();

            entity.HasOne(d => d.BillingPlan).WithMany(p => p.Invoices).HasConstraintName("FK__Invoice__Billing__4AB81AF0");

            entity.HasOne(d => d.BusinessUnit).WithMany(p => p.Invoices).HasConstraintName("FK__Invoice__Busines__49C3F6B7");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId).HasName("PK__PaymentM__DC31C1F3064B2068");

            entity.Property(e => e.PaymentMethodId).ValueGeneratedNever();

            entity.HasOne(d => d.CustomerAccountingInfo).WithMany(p => p.PaymentMethods).HasConstraintName("FK__PaymentMe__Custo__44FF419A");
        });

        modelBuilder.Entity<UsageRecord>(entity =>
        {
            entity.HasKey(e => e.UsageId).HasName("PK__UsageRec__29B197C0B81B79BA");

            entity.Property(e => e.UsageId).ValueGeneratedNever();
            entity.Property(e => e.TotalCost).HasComputedColumnSql("([Quantity]*[UnitPrice])", true);

            entity.HasOne(d => d.CustomerAccountingInfo).WithMany(p => p.UsageRecords).HasConstraintName("FK__UsageReco__Custo__4D94879B");

            entity.HasOne(d => d.Invoice).WithMany(p => p.UsageRecords).HasConstraintName("FK__UsageReco__Invoi__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
