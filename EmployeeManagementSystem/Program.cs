
using EmployeeManagementSystem.Interface.Repositories;
using EmployeeManagementSystem.Interface.Services;
using EmployeeManagementSystem.Middlewares;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.Implementation;
using EmployeeManagementSystem.Service.Implementation;
using EmployeeManagementSystem.Services.Implementation;
using EmployeeManagementSystem.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;


namespace EmployeeManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Accept the license
            QuestPDF.Settings.License = LicenseType.Community;

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           
            builder.Services.AddDbContext<EmployeemanagementContext>(options =>
                    options.UseMySql(
                        builder.Configuration.GetConnectionString("DbConnect"),
                        new MySqlServerVersion(new Version(8, 0, 21))
                    ));
            builder.Services.AddLogging();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeDepartmentPayrollService, EmployeeDepartmentPayrollService>();
            builder.Services.AddScoped<IEmployeeDepartmentPayrollRepository, EmployeeDepartmentPayrollRepository>();
            builder.Services.AddScoped<IPayrollService, PayrollService>();
            builder.Services.AddScoped<IPayrollRepository, PayrollRepository>();

            builder.Services.AddScoped<IUnitOfWork,UnitofWorks>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
