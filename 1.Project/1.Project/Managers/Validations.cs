namespace EmployeeManagementSystem
{

    using System;
    using System.Text.RegularExpressions;

    //Partial Class for Validation of Manual Adding Employees
    public static partial class Validator
    {

        private static T GetValidInput<T>(string prompt, Func<string, (bool isValid, T value)> parser, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                var (isValid, value) = parser(input);
                if (isValid)
                    return value;

                Console.WriteLine(errorMessage);
            }
        }

        //Validation for Getting Valid Department
        public static TEnum GetValidEnum<TEnum>(string prompt) where TEnum : struct, Enum
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Trim();

                if (Enum.TryParse<TEnum>(input, ignoreCase: true, out var result) && Enum.IsDefined(typeof(TEnum), result))
                    return result;

                Console.WriteLine($"Invalid input. Please enter one of the following values: {string.Join(", ", Enum.GetNames(typeof(TEnum)))}");
            }
        }

        //Validation for Getting Valid Job Role
        public static JobRole GetValidRole<JobRole>(string prompt) where JobRole : struct, Enum
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Trim();

                if (Enum.TryParse<JobRole>(input, ignoreCase: true, out var result) && Enum.IsDefined(typeof(JobRole), result))
                    return result;

                Console.WriteLine($"Invalid input. Please enter one of the following values: {string.Join(", ", Enum.GetNames(typeof(JobRole)))}");
            }
        }


        //Validation for Getting Valid Integer
        public static int GetValidInt(string prompt) => GetValidInput(prompt, input => (int.TryParse(input, out var val), val), "Invalid input. Please enter a valid integer.");

        //Validation for Getting Valid ID
        public static int GetValidId(string prompt)
        {
            int id;
            while (true)
            {
                id = GetValidInt(prompt);
                if (id > 0)
                    return id;

                Console.WriteLine("ID must be a positive integer. Please try again.");
            }
        }


        //Validation for Getting Valid Age
        public static int GetValidAge(string prompt)
        {
            int id;
            while (true)
            {
                id = GetValidInt(prompt);
                if (id > 17 && id < 69)
                    return id;

                Console.WriteLine("Age must be in between 18 - 69. Please try again.");
            }
        }


        //Validation for Getting Valid Decimals Numbers
        public static decimal GetValidDecimal(string prompt) =>
            GetValidInput(prompt,
                          input => (decimal.TryParse(input, out var val), val),
                          "Invalid input. Please enter a valid decimal number.");


        //Validation for Getting Valid Strings
        public static string GetValidString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                    continue;
                }
                return input;
            }
        }

        //Validation for Getting Valid Name
        public static string GetValidName(string prompt)
        {
            while (true)
            {
                string input = GetValidString(prompt);

                if (Regex.IsMatch(input, @"^[A-Za-z\s]+$"))
                {
                    return input;
                }

                Console.WriteLine("Invalid input. Only letters and spaces are allowed.");
            }
        }

        //Validation for Getting Valid Address Street
        public static string GetValidAddressStreet(string prompt)
        {
            string input = GetValidString(prompt);
            return input;
        }

        //Validation for Getting Valid Address City
        public static string GetValidAddressCity(string prompt)
        {
            while (true)
            {
                string input = GetValidString(prompt);

                if (Regex.IsMatch(input, @"^[A-Za-z\s]+$"))
                {
                    return input;
                }

                Console.WriteLine("City name is incorrect.");
            }
        }

        //Validation for Getting Valid Address State
        public static string GetValidAddressState(string prompt)
        {
            while (true)
            {
                string input = GetValidString(prompt);

                if (Regex.IsMatch(input, @"^[A-Za-z\s]+$"))
                {
                    return input;
                }

                Console.WriteLine("State name is incorrect.");
            }
        }

        //Validation for Getting Valid Address Pin-Code
        public static string GetValidAddressPin(string prompt)
        {
            while (true)
            {
                string input = GetValidString(prompt);

                if (Regex.IsMatch(input, @"^\d{6}$"))
                {
                    return input;
                }

                Console.WriteLine("this pincode is not correct.");
            }
        }

        //Validation for Getting Valid (y/n)
        public static bool GetYesOrNo(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " (y/n) : ");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "y") return true;
                if (input == "n") return false;

                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
            }
        }
    }

}