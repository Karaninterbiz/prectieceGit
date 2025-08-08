namespace EmployeeManagementSystem
{
    //Employee Class and Child Classes
    public abstract class Employee : IEmployeeActions
    {
        //For All the Employees
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Department Department { get; set; }
        public JobRole Role { get; set; }
        public Address Address { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public DateTime? DateOfExit { get; set; }

        public virtual void DisplayDetails() { }
        public abstract decimal CalculateSalary();
    }

    public class FullTimeEmployee : Employee
    {
        //For All the FullTime Employees

        private string dept;
        private decimal salary;

        public FullTimeEmployee()
        {
        }

        public FullTimeEmployee(int id, string name, string dept, decimal salary, decimal bonus)
        {
            Id = id;
            Name = name;
            this.dept = dept;
            this.salary = salary;
            Bonus = bonus;
        }

        public decimal MonthlySalary { get; set; }
        public decimal Bonus { get; set; }


        //overriden the Methods from the Employee class
        public override decimal CalculateSalary()
        {
            if (MonthlySalary < 0 || Bonus < 0)
                throw new SalaryCalculationException("salary or bonus cannot be negative.");

            return MonthlySalary + Bonus;
        }
        public override void DisplayDetails()
        {
            Console.WriteLine("Full Time Employee Details :- ");
            Console.WriteLine($" ID : {Id}, Name : {Name}, Dept : {Department}, Role : {Role}, Salary : {MonthlySalary}, Bonus : {Bonus}".ToUpper());
        }
    }

    public class PartTimeEmployee : Employee
    {
        //For All the Parttime Employees

        private string dept;
        private decimal hourly;
        private int hours;

        public PartTimeEmployee()
        {
        }

        public PartTimeEmployee(int id, string name, string dept, decimal hourly, int hours)
        {
            Id = id;
            Name = name;
            this.dept = dept;
            this.hourly = hourly;
            this.hours = hours;
        }

        public decimal HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        //overriden the Methods from the Employee class

        public override decimal CalculateSalary()
        {
            if (HoursWorked < 0 || HourlyRate < 0)
                throw new SalaryCalculationException("Hourly Rate and hours worked cannot be negative.");

            return HourlyRate * HoursWorked;
        }
        public override void DisplayDetails()
        {
            Console.WriteLine("Part Time Employee Details :- ");
            Console.WriteLine($" ID : {Id}, Name : {Name}, Dept : {Department}, Role : {Role}, Hourly Rate : {HourlyRate}, Hours Worked : {HoursWorked}".ToUpper());
        }
    }
}