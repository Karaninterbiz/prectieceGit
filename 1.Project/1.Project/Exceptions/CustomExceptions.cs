namespace EmployeeManagementSystem
{
    //Classes Inheriting the Exception and making Custom Exceptions
    public class InvalidEmployeeIdException : Exception
    {

        //Method Throw an error with a clear name and message
        public InvalidEmployeeIdException(string message) : base(message) { }
    }

    public class SalaryCalculationException : Exception
    {

        //Method Throw an error with a clear name and message
        public SalaryCalculationException(string message) : base(message) { }
    }
}