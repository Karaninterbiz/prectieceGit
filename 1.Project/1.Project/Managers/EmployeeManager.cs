namespace EmployeeManagementSystem
{
    //class for Employee Manager
    public class EmployeeManager
    {

        //using Generic Collection i.e. Dictionary to store the Employee Details
        private Dictionary<int, Employee> employees = new Dictionary<int, Employee>();


        //Checks the Employee is already present in the System
        public void AddEmployee(Employee emp)
        {
            if (employees.ContainsKey(emp.Id))
                throw new InvalidEmployeeIdException("Employee with this ID already exists.");

            employees.Add(emp.Id, emp);
        }

        //Print the Employee present in the System
        public void ListAllEmployees()
        {
            if (!employees.Any())
            {
                Console.WriteLine("No employees found.");
                return;
            }

            foreach (var emp in employees)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine(emp.ToString().ToUpper());
            }
        }

        //Checks and Print the Employee if present in the System
        public Employee GetEmployeeById(int id)
        {
            if (!employees.ContainsKey(id))
            {
                return null;
            }

            return employees[id];
        }

        //Checks and Delete the Employee if present in the System
        public bool DeleteEmployee(int id)
        {
            if (!employees.ContainsKey(id))
            {
                return false;
            }

            employees.Remove(id);


            return true;
        }

        //Checks if the Employee is present for Modifications
        public bool UpdateEmployee(Employee emp)
        {
            if (!employees.ContainsKey(emp.Id))
            {
                return false;
            }

            employees[emp.Id] = emp;


            return true;
        }

        
        public void CalculateSalary(int id) { }


    }
}