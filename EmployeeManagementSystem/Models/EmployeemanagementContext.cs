using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace EmployeeManagementSystem.Models;

public partial class EmployeemanagementContext : DbContext
{
    public EmployeemanagementContext()
    {
    }

    public EmployeemanagementContext(DbContextOptions<EmployeemanagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employeeproject> Employeeprojects { get; set; }

    public virtual DbSet<Payroll> Payrolls { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }
    public DbSet<PerformanceReview> PerformanceReviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=employeemanagement;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.41-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PRIMARY");

            entity.ToTable("attendance");

            entity.HasIndex(e => e.EmployeeId, "fk_empl");

            entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");
            entity.Property(e => e.CheckInTime).HasColumnType("time");
            entity.Property(e => e.CheckOutTime).HasColumnType("time");
            entity.Property(e => e.Status).HasColumnType("enum('OnTime','Late','Absent')");

            entity.HasOne(d => d.Employee).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_empl");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepId).HasName("PRIMARY");

            entity.ToTable("department");

            entity.HasIndex(e => e.DepName, "DepName_UNIQUE").IsUnique();

            entity.Property(e => e.DepId).ValueGeneratedNever();
            entity.Property(e => e.DepName).HasMaxLength(25);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Eid).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.DepartmentId, "fk_department");

            entity.HasIndex(e => e.RoleId, "fk_role");

            entity.Property(e => e.Eid)
                .ValueGeneratedNever()
                .HasColumnName("EId");
            entity.Property(e => e.FirstName).HasMaxLength(25);
            entity.Property(e => e.LastName).HasMaxLength(25);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_department");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role");
        });

        modelBuilder.Entity<Employeeproject>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("employeeproject");

            entity.HasIndex(e => e.EmployeeId, "fk_employee");

            entity.HasIndex(e => e.ProjectId, "fk_project");

            entity.HasIndex(e => e.RoleId, "fk_role_pr");

            entity.HasOne(d => d.Employee).WithMany()
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("fk_employee");

            entity.HasOne(d => d.Project).WithMany()
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("fk_project");

            entity.HasOne(d => d.Role).WithMany()
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("fk_role_pr");
        });

        modelBuilder.Entity<Payroll>(entity =>
        {
            entity.HasKey(e => e.PrId).HasName("PRIMARY");

            entity.ToTable("payroll");

            entity.HasIndex(e => e.EmployeeId, "fk_empl_pr");

            entity.HasOne(d => d.Employee).WithMany(p => p.Payrolls)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_empl_pr");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.PrId).HasName("PRIMARY");

            entity.ToTable("project");

            entity.HasIndex(e => e.PrName, "PrName_UNIQUE").IsUnique();

            entity.Property(e => e.PrId).ValueGeneratedNever();
            entity.Property(e => e.PrName).HasMaxLength(50);
            entity.Property(e => e.PrStatus).HasColumnType("enum('Ongoing','Completed')");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.HasIndex(e => e.RoleName, "RoleName_UNIQUE").IsUnique();

            entity.Property(e => e.RoleId).ValueGeneratedNever();
            entity.Property(e => e.RoleName).HasMaxLength(25);
        });

        modelBuilder.Entity<PerformanceReview>(entity =>
        {
            modelBuilder.Entity<PerformanceReview>()
                .Property(p => p.ReviewDate)
                .HasColumnType("date");

            entity.Property(p => p.Rating)
                .IsRequired();


            entity.HasOne(em => em.Employee).WithMany(e => e.PerformanceReviews)
                .HasForeignKey(em => em.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_em"); ;
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
