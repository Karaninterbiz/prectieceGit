
namespace EmployeeManagementSystem
{
    using System.ComponentModel.DataAnnotations;
    using System.Security;
    using EmployeeManagementSystem.Services;
    using static EmployeeServices;
    class Program
    {

        static void Main(string[] args)
        {

            //Object for Using all the Present Services
            EmployeeServices employeeServices = new EmployeeServices();
            BulkImportService bulkImportService = new BulkImportService();

            //Object of Delegate for calling Bulk Importing Methods
            ImportDelegate importDelegate = new ImportDelegate(bulkImportService.BulkImportEmployees);

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("==== Employee Management System ====");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. List All Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Update Employee");
                Console.WriteLine("6. Calculate Salary");
                Console.WriteLine("7. BulkImportEmployees");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "0": exit = true; break;
                    case "1": employeeServices.AddEmployeeService(); break;
                    case "2": employeeServices.ViewAllEmployeesService(); break;
                    case "3": employeeServices.SearchEmployeeByIdService(); break;
                    case "4": employeeServices.DeleteEmployeeService(); break;
                    case "5": employeeServices.UpdateEmployeeService(); break;
                    case "6": employeeServices.CalculateSalaryService(); break;
                    case "7": importDelegate(); break;

                    //For all Inputs other than 1 to 7
                    default: Console.WriteLine("Invalid Option"); break;
                }
                Console.ReadKey();
            }
        }

    }
}