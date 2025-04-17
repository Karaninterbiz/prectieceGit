using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddPerformaceRatingColumnToEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.AddColumn<int>(
               name: "PerformanceRating",
               table: "employee",
               type: "int",
               nullable: false,
               defaultValue: 0);
            //migrationBuilder.AlterDatabase()
            //    .Annotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.CreateTable(
            //    name: "department",
            //    columns: table => new
            //    {
            //        DepId = table.Column<int>(type: "int", nullable: false),
            //        DepName = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false, collation: "utf8mb4_0900_ai_ci")
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PRIMARY", x => x.DepId);
            //    })
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            //migrationBuilder.CreateTable(
            //    name: "project",
            //    columns: table => new
            //    {
            //        PrId = table.Column<int>(type: "int", nullable: false),
            //        PrName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        PrStatus = table.Column<string>(type: "enum('Ongoing','Completed')", nullable: false, collation: "utf8mb4_0900_ai_ci")
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        PrStartDate = table.Column<DateOnly>(type: "date", nullable: false),
            //        ExpectedCompletionDate = table.Column<DateOnly>(type: "date", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PRIMARY", x => x.PrId);
            //    })
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            //migrationBuilder.CreateTable(
            //    name: "roles",
            //    columns: table => new
            //    {
            //        RoleId = table.Column<int>(type: "int", nullable: false),
            //        RoleName = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false, collation: "utf8mb4_0900_ai_ci")
            //            .Annotation("MySql:CharSet", "utf8mb4")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PRIMARY", x => x.RoleId);
            //    })
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            //migrationBuilder.CreateTable(
            //    name: "employee",
            //    columns: table => new
            //    {
            //        EId = table.Column<int>(type: "int", nullable: false),
            //        FirstName = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false, collation: "utf8mb4_0900_ai_ci")
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        LastName = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true, collation: "utf8mb4_0900_ai_ci")
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        HireDate = table.Column<DateOnly>(type: "date", nullable: false),
            //        DepartmentId = table.Column<int>(type: "int", nullable: false),
            //        RoleId = table.Column<int>(type: "int", nullable: false),
            //        PerformanceRating = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PRIMARY", x => x.EId);
            //        table.ForeignKey(
            //            name: "fk_department",
            //            column: x => x.DepartmentId,
            //            principalTable: "department",
            //            principalColumn: "DepId");
            //        table.ForeignKey(
            //            name: "fk_role",
            //            column: x => x.RoleId,
            //            principalTable: "roles",
            //            principalColumn: "RoleId");
            //    })
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            //migrationBuilder.CreateTable(
            //    name: "attendance",
            //    columns: table => new
            //    {
            //        AttendanceID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //        Date = table.Column<DateOnly>(type: "date", nullable: false),
            //        CheckInTime = table.Column<TimeOnly>(type: "time", nullable: true),
            //        CheckOutTime = table.Column<TimeOnly>(type: "time", nullable: true),
            //        Status = table.Column<string>(type: "enum('OnTime','Late','Absent')", nullable: false, collation: "utf8mb4_0900_ai_ci")
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        EmployeeId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PRIMARY", x => x.AttendanceID);
            //        table.ForeignKey(
            //            name: "fk_empl",
            //            column: x => x.EmployeeId,
            //            principalTable: "employee",
            //            principalColumn: "EId");
            //    })
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            //migrationBuilder.CreateTable(
            //    name: "employeeproject",
            //    columns: table => new
            //    {
            //        EmployeeId = table.Column<int>(type: "int", nullable: true),
            //        ProjectId = table.Column<int>(type: "int", nullable: true),
            //        RoleId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.ForeignKey(
            //            name: "fk_employee",
            //            column: x => x.EmployeeId,
            //            principalTable: "employee",
            //            principalColumn: "EId");
            //        table.ForeignKey(
            //            name: "fk_project",
            //            column: x => x.ProjectId,
            //            principalTable: "project",
            //            principalColumn: "PrId");
            //        table.ForeignKey(
            //            name: "fk_role_pr",
            //            column: x => x.RoleId,
            //            principalTable: "roles",
            //            principalColumn: "RoleId");
            //    })
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            //migrationBuilder.CreateTable(
            //    name: "payroll",
            //    columns: table => new
            //    {
            //        PrId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //        BaseSalary = table.Column<double>(type: "double", nullable: false),
            //        Bonus = table.Column<double>(type: "double", nullable: true),
            //        Deductions = table.Column<double>(type: "double", nullable: true),
            //        Netpay = table.Column<double>(type: "double", nullable: false),
            //        PayDate = table.Column<DateOnly>(type: "date", nullable: false),
            //        EmployeeId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PRIMARY", x => x.PrId);
            //        table.ForeignKey(
            //            name: "fk_empl_pr",
            //            column: x => x.EmployeeId,
            //            principalTable: "employee",
            //            principalColumn: "EId");
            //    })
            //    .Annotation("MySql:CharSet", "utf8mb4")
            //    .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            //migrationBuilder.CreateIndex(
            //    name: "fk_empl",
            //    table: "attendance",
            //    column: "EmployeeId");

            //migrationBuilder.CreateIndex(
            //    name: "DepName_UNIQUE",
            //    table: "department",
            //    column: "DepName",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "fk_department",
            //    table: "employee",
            //    column: "DepartmentId");

            //migrationBuilder.CreateIndex(
            //    name: "fk_role",
            //    table: "employee",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "fk_employee",
            //    table: "employeeproject",
            //    column: "EmployeeId");

            //migrationBuilder.CreateIndex(
            //    name: "fk_project",
            //    table: "employeeproject",
            //    column: "ProjectId");

            //migrationBuilder.CreateIndex(
            //    name: "fk_role_pr",
            //    table: "employeeproject",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "fk_empl_pr",
            //    table: "payroll",
            //    column: "EmployeeId");

            //migrationBuilder.CreateIndex(
            //    name: "PrName_UNIQUE",
            //    table: "project",
            //    column: "PrName",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "RoleName_UNIQUE",
            //    table: "roles",
            //    column: "RoleName",
            //    unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
              name: "PerformanceRating",
              table: "employee");
            //migrationBuilder.DropTable(
            //    name: "attendance");

            //migrationBuilder.DropTable(
            //    name: "employeeproject");

            //migrationBuilder.DropTable(
            //    name: "payroll");

            //migrationBuilder.DropTable(
            //    name: "project");

            //migrationBuilder.DropTable(
            //    name: "employee");

            //migrationBuilder.DropTable(
            //    name: "department");

            //migrationBuilder.DropTable(
            //    name: "roles");
        }
    }
}
