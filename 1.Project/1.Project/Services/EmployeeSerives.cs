namespace EmployeeManagementSystem
{

    //Importing the Employee Service Interface to use it's Methods
    public class EmployeeServices : IEmployeeServices 
    {

        //Object for using Employee Manager Methods
        EmployeeManager manager = new EmployeeManager();


        

        //This Method is used to add new Employee in our System.
        public void AddEmployeeService()
        {
            int id = Validator.GetValidId("Enter the employee ID : ");

            string name = Validator.GetValidName("Enter the employee name : ");

            int age = Validator.GetValidAge("Enter the employee age : ");

            Console.Write("Enter Department (HR, Developer, BPO, Others)");
            Department depart = Validator.GetValidEnum<Department>("Enter department: ");

            Console.Write("Enter Job Role (ClientSide, ServerSide, Tester, Manager, Servicer, Civil, Cook, Electrician, Others)");
            JobRole role = Validator.GetValidRole<JobRole>("Enter Job Role : ");

            string street = Validator.GetValidAddressStreet("Enter the Address Street : ");

            string city = Validator.GetValidAddressCity("Enter the Address City : ");

            string state = Validator.GetValidAddressState("Enter the Address State : ");

            string pin = Validator.GetValidAddressPin("Enter the Address Pin-code : ");

            Address addr = new Address { Street = street, City = city, State = state, PinCode = pin };

            bool type = Validator.GetYesOrNo("Is this Employee is Fulltime employee ?");

            Employee emp = null;

            //Check the Employee is Fulltime
            if (type)
            {
                decimal salary = Validator.GetValidDecimal("Enter the Employee Salary : ");

                decimal bonus = Validator.GetValidDecimal("Enter the Employee bonus : ");

                emp = new FullTimeEmployee()
                {
                    Id = id,
                    Name = name,
                    Age = age,
                    Department = depart,
                    Role = role,
                    Address = addr,
                    MonthlySalary = salary,
                    Bonus = bonus
                };
            }

            //Employee is Parttime Employee.
            else
            {

                decimal rate = Validator.GetValidDecimal("Enter the Employee Hourly rate : "); ;

                int hours = Validator.GetValidInt("Enter the Employee Work Hours : ");

                emp = new PartTimeEmployee()
                {
                    Id = id,
                    Name = name,
                    Age = age,
                    Department = depart,
                    Role = role,
                    Address = addr,
                    HourlyRate = rate,
                    HoursWorked = hours
                };
            }

            //Employee is added in the Dictionary
            manager.AddEmployee(emp);
            Console.WriteLine("Employee added successfully");
        }

        //Show the all Employees present in the System
        public void ViewAllEmployeesService()
        {
            Console.WriteLine("=== View All Employees ===");
            manager.ListAllEmployees();
        }


        //Show the Details of Specific Employee 
        public void SearchEmployeeByIdService()
        {
            Console.Write("Enter Employee ID to search : ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {

                try
                {
                    var employee = manager.GetEmployeeById(id);
                    if (employee != null)
                    {
                        employee.DisplayDetails();
                    }

                    else
                    {
                        Console.WriteLine("Employee not found.");
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error occurred : " + ex.Message);
                }

                finally
                {
                    Console.WriteLine("This is the Personal Informations of Employee.");
                }
            }

            else
            {
                Console.WriteLine("Invalid ID format.");
            }
        }

        //Remove the Specific Employee Present in the System
        public void DeleteEmployeeService()
        {
            Console.WriteLine("Enter Employee ID to delete : ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                try
                {
                    bool result = manager.DeleteEmployee(id);
                    if (result)
                        Console.WriteLine("Employee deleted successfully.");

                    else
                        Console.WriteLine("Employee not found.");
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error : " + ex.Message);
                }

                finally
                {
                    Console.WriteLine("The Deleted Data will never Recover.");
                }
            }

            else
            {
                Console.WriteLine("Invalid input, please enter a valid number.");
            }
        }

        //Changes the information of Employee Present in the System
        public void UpdateEmployeeService()
        {
            Console.WriteLine("Update Process Begins...");
            Console.Write("Enter the employee ID you want to update : ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            var employee = manager.GetEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            Console.WriteLine("Leave input blank to skip updating the Employee Details");

            Console.Write($"Current Name : {employee.Name}. New Name : ");
            string name = Console.ReadLine();

            if (!string.IsNullOrEmpty(name))
                employee.Name = name;

            Console.Write($"Current Age : {employee.Age}. New Age : ");
            string ageInput = Console.ReadLine();

            if (int.TryParse(ageInput, out int newAge))
                employee.Age = newAge;

            Console.Write($"Current Department : {employee.Department}. New Department : ");
            string deptInput = Console.ReadLine();

            if (Enum.TryParse<Department>(deptInput, true, out var dept))
                employee.Department = dept;

            Console.Write($"Current Role : {employee.Role}. New Role : ");
            string roleInput = Console.ReadLine();

            if (Enum.TryParse<JobRole>(roleInput, true, out var role))
                employee.Role = role;

            Console.Write("Update Address : ");
            Console.Write("street : ");
            string street = Console.ReadLine();
            Console.Write("city : ");
            string city = Console.ReadLine();
            Console.Write("state : ");
            string state = Console.ReadLine();
            Console.Write("Pin Code : ");
            string pin = Console.ReadLine();

            employee.Address = new Address
            {
                Street = string.IsNullOrWhiteSpace(street) ? employee.Address.Street : street,
                City = string.IsNullOrWhiteSpace(city) ? employee.Address.City : city,
                State = string.IsNullOrWhiteSpace(state) ? employee.Address.State : state,
                PinCode = string.IsNullOrWhiteSpace(pin) ? employee.Address.PinCode : pin
            };

            if (employee is FullTimeEmployee ft)
            {
                Console.Write($"Current Salary : {ft.MonthlySalary}. New Salary : ");
                string salInput = Console.ReadLine();

                if (decimal.TryParse(salInput, out var sal)) ft.MonthlySalary = sal;

                Console.Write($"Current Bonus : {ft.Bonus}. New Bonus : ");
                string bonusInput = Console.ReadLine();

                if (decimal.TryParse(bonusInput, out var bonus)) ft.Bonus = bonus;
            }

            else if (employee is PartTimeEmployee pt)
            {
                Console.Write($"Current Hourly Rate : {pt.HourlyRate}. New Rate : ");
                string rateInput = Console.ReadLine();
                if (decimal.TryParse(rateInput, out var rate)) pt.HourlyRate = rate;

                Console.Write($"Current Hours Worked : {pt.HoursWorked}. New Hours : ");
                string hoursInput = Console.ReadLine();
                if (int.TryParse(hoursInput, out var hours)) pt.HoursWorked = hours;
            }

            manager.UpdateEmployee(employee);
            Console.WriteLine("Employee details has been updated successfully!");
        }


        //Gives the total Salary of the Employee present in the system
        public void CalculateSalaryService()
        {
            Console.Write("Enter Employee ID : ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            var employee = manager.GetEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            // using try catch block for the error handling
            try
            {
                decimal salary = employee.CalculateSalary();
                Console.WriteLine($"Calculated Salary for {employee.Name} (ID : {employee.Id}) = {salary}");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error in salary calculation : " + ex.Message);
            }
        }

        
        //public void BulkImportEmployeesService() 
        //{
        //    Console.Write("Enter file path for bulk import: ");
        //    string? filePath = Console.ReadLine();

        //    if (!File.Exists(filePath))
        //    {
        //        Console.WriteLine("File not found.");
        //        return;
        //    }

        //    string[] lines = File.ReadAllLines(filePath);
        //    int successCount = 0, failCount = 0;


        //    //Created the new Thread for reading all the texts from File
        //    Thread importThread = new Thread(() =>
        //    {
        //        foreach (var line in lines)
        //        {
        //            try
        //            {
        //                //Takes all the lines, break them and store in variables
        //                if (string.IsNullOrWhiteSpace(line)) continue;

        //                string[] parts = line.Split(',');

        //                string empType = parts[0].Trim();

        //                int id = Validator.GetValidIdFromFile(parts[1]);
        //                string name = Validator.GetValidNameFromFile(parts[2]);
        //                int age = Validator.GetValidAgeFromFile(parts[3]);
        //                Department dept = Validator.GetValidEnumFromFile<Department>(parts[4]);
        //                JobRole role = Validator.GetValidEnumFromFile<JobRole>(parts[5]);
        //                string street = Validator.GetValidAddressStreetFromFile(parts[6]);
        //                string city = Validator.GetValidAddressCityFromFile(parts[7]);
        //                string state = Validator.GetValidAddressStateFromFile(parts[8]);
        //                string pin = Validator.GetValidAddressPinFromFile(parts[9]);

        //                Address addr = new Address
        //                {
        //                    Street = street,
        //                    City = city,
        //                    State = state,
        //                    PinCode = pin
        //                };

        //                Employee emp = null;

        //                //Checks for Fulltime Employee
        //                if (empType.Equals("FullTime", StringComparison.OrdinalIgnoreCase))
        //                {
        //                    decimal salary = Validator.GetValidDecimalFromFile(parts[10]);
        //                    decimal bonus = Validator.GetValidDecimalFromFile(parts[11]);

        //                    emp = new FullTimeEmployee()
        //                    {
        //                        Id = id,
        //                        Name = name,
        //                        Age = age,
        //                        Department = dept,
        //                        Role = role,
        //                        Address = addr,
        //                        MonthlySalary = salary,
        //                        Bonus = bonus
        //                    };
        //                }

        //                //otherwise Partime Employee 
        //                else if (empType.Equals("PartTime", StringComparison.OrdinalIgnoreCase))
        //                {
        //                    decimal rate = Validator.GetValidDecimalFromFile(parts[10]);
        //                    int hours = Validator.GetValidIntFromFile(parts[11]);

        //                    emp = new PartTimeEmployee()
        //                    {
        //                        Id = id,
        //                        Name = name,
        //                        Age = age,
        //                        Department = dept,
        //                        Role = role,
        //                        Address = addr,
        //                        HourlyRate = rate,
        //                        HoursWorked = hours
        //                    };
        //                }
        //                else
        //                {
        //                    throw new Exception($"Unknown employee type '{empType}'");
        //                }

        //                manager.AddEmployee(emp);
        //                successCount++;
        //            }
        //            catch (Exception ex)
        //            {
        //                failCount++;
        //                Console.WriteLine($"Error importing line: {line}");
        //                Console.WriteLine($"Reason: {ex.Message}");
        //            }
        //        }
        //    });

        //    importThread.Start();

        //    //Gives all the Valid informations to the System and Message for Inavlid ones
        //    Console.WriteLine($"Import completed. {successCount} added, {failCount} failed.");
        //}
    }
}