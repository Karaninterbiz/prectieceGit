namespace EmployeeManagementSystem.Services
{
    //Delegate is created
    public delegate void ImportDelegate();
    class BulkImportService : IDisposable
    {
        private readonly EmployeeManager manager;
        private StreamReader? reader;
        private bool disposed = false;

        public BulkImportService(){ }
        public BulkImportService(EmployeeManager manager)
        {
            this.manager = manager;
        }

        public void BulkImportEmployees()
        {

            Console.Write("Enter file path for bulk import: ");
            string? filePath = Console.ReadLine();

            
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }

            reader = new StreamReader(filePath);
            int successCount = 0, failCount = 0;

            Thread importThread = new Thread(() =>
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        string[] parts = line.Split(',');
                        string empType = parts[0].Trim();

                        int id = Validator.GetValidIdFromFile(parts[1]);
                        string name = Validator.GetValidNameFromFile(parts[2]);
                        int age = Validator.GetValidAgeFromFile(parts[3]);
                        Department dept = Validator.GetValidEnumFromFile<Department>(parts[4]);
                        JobRole role = Validator.GetValidEnumFromFile<JobRole>(parts[5]);
                        string street = Validator.GetValidAddressStreetFromFile(parts[6]);
                        string city = Validator.GetValidAddressCityFromFile(parts[7]);
                        string state = Validator.GetValidAddressStateFromFile(parts[8]);
                        string pin = Validator.GetValidAddressPinFromFile(parts[9]);

                        Address addr = new Address
                        {
                            Street = street,
                            City = city,
                            State = state,
                            PinCode = pin
                        };

                        Employee emp = null;

                        if (empType.Equals("FullTime", StringComparison.OrdinalIgnoreCase))
                        {
                            decimal salary = Validator.GetValidDecimalFromFile(parts[10]);
                            decimal bonus = Validator.GetValidDecimalFromFile(parts[11]);

                            emp = new FullTimeEmployee
                            {
                                Id = id,
                                Name = name,
                                Age = age,
                                Department = dept,
                                Role = role,
                                Address = addr,
                                MonthlySalary = salary,
                                Bonus = bonus
                            };
                        }
                        else if (empType.Equals("PartTime", StringComparison.OrdinalIgnoreCase))
                        {
                            decimal rate = Validator.GetValidDecimalFromFile(parts[10]);
                            int hours = Validator.GetValidIntFromFile(parts[11]);

                            emp = new PartTimeEmployee
                            {
                                Id = id,
                                Name = name,
                                Age = age,
                                Department = dept,
                                Role = role,
                                Address = addr,
                                HourlyRate = rate,
                                HoursWorked = hours
                            };
                        }
                        else
                        {
                            throw new Exception($"Unknown employee type '{empType}'");
                        }

                        manager.AddEmployee(emp);
                        successCount++;
                    }
                    catch (Exception ex)
                    {
                        failCount++;
                        Console.WriteLine($"Error importing line: {line}");
                        Console.WriteLine($"Reason: {ex.Message}");
                    }
                }

                Console.WriteLine($"Import completed. {successCount} added, {failCount} failed.");
            });

            importThread.Start();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    reader?.Dispose();
                }
                disposed = true;
            }
        }

        ~BulkImportService()
        {
            Dispose(false);
        }
    }

}