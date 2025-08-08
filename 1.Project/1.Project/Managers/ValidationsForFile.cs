namespace EmployeeManagementSystem
{
    using System;
    using System.Text.RegularExpressions;

    //Partial Class for Validation of Files Importing Employees
    public static partial class Validator
    {
        //Validation for Getting Valid Number
        public static int GetValidIntFromFile(string value)
        {
            if (!int.TryParse(value, out int result))
                throw new ArgumentException("Invalid integer value.");
            return result;
        }

        //Validation for Getting Valid ID
        public static int GetValidIdFromFile(string value)
        {
            if (!int.TryParse(value, out int id) || id <= 0)
                throw new ArgumentException("ID must be a positive integer.");
            return id;
        }

        //Validation for Getting Valid Age
        public static int GetValidAgeFromFile(string value)
        {
            if (!int.TryParse(value, out int age) || age < 18 || age > 69)
                throw new ArgumentException("Age must be between 18 and 69.");
            return age;
        }

        //Validation for Getting Valid Decimals Numbers
        public static decimal GetValidDecimalFromFile(string value)
        {
            if (!decimal.TryParse(value, out decimal result))
                throw new ArgumentException("Invalid decimal number.");
            return result;
        }

        //Validation for Getting Valid Name
        public static string GetValidNameFromFile(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty.");
            if (!Regex.IsMatch(value, @"^[A-Za-z\s]+$"))
                throw new ArgumentException("Invalid name. Only letters and spaces allowed.");
            return value.Trim();
        }

        //Validation for Getting Valid Address Street
        public static string GetValidAddressStreetFromFile(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Street cannot be empty.");
            return value.Trim();
        }

        //Validation for Getting Valid Address City
        public static string GetValidAddressCityFromFile(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^[A-Za-z\s]+$"))
                throw new ArgumentException("Invalid city name.");
            return value.Trim();
        }

        //Validation for Getting Valid Address State
        public static string GetValidAddressStateFromFile(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^[A-Za-z\s]+$"))
                throw new ArgumentException("Invalid state name.");
            return value.Trim();
        }

        //Validation for Getting Valid Address Pin-Code
        public static string GetValidAddressPinFromFile(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^\d{6}$"))
                throw new ArgumentException("Invalid pincode. Must be 6 digits.");
            return value.Trim();
        }


        public static bool GetYesOrNoFromFile(string value)
        {
            value = value.Trim().ToLower();
            if (value == "y" || value == "yes") return true;
            if (value == "n" || value == "no") return false;
            throw new ArgumentException("Invalid Yes/No value.");
        }

        //Validation for Getting Valid Department and Job Role
        public static TEnum GetValidEnumFromFile<TEnum>(string value) where TEnum : struct, Enum
        {
            if (Enum.TryParse<TEnum>(value, true, out var result) && Enum.IsDefined(typeof(TEnum), result))
                return result;
            throw new ArgumentException($"Invalid value '{value}'. Allowed: {string.Join(", ", Enum.GetNames(typeof(TEnum)))}");
        }

        public static TEnum GetValidRoleFromFile<TEnum>(string value) where TEnum : struct, Enum =>
            GetValidEnumFromFile<TEnum>(value);
    }

}