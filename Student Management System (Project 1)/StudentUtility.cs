using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Student_Management_System__Project_1_
{
    public static class ExtentionMethods
    {
        public static void DisplayStudentInfo(this List<Student> students, bool duration)
        {
            try
            {
                if (students.Count == 0)
                {
                    Console.WriteLine("There is no Student in the List");
                }
                else
                {
                    Console.WriteLine(new string('-', 40));

                    if (duration)
                    {
                        Console.WriteLine("Students will be listed every 10 seconds");
                    }
                    else
                    {
                        Console.WriteLine($"Here are the {students.Count} students:");
                    }

                    Console.WriteLine();

                    foreach (var item in students)
                    {
                        string firstName = item?.FirstName ?? string.Empty;
                        string middleName = item?.MiddleName ?? string.Empty;
                        string lastName = item?.LastName ?? string.Empty;
                        int age = item.Age;
                        int rollNo = item.RollNo;
                        string address = item.Address;
                        string classIn = item.ClassIn.ToString();
                        string admissionDate = item.AdmissionDate;
                        List<string> hobbies = item.Hobbies ?? new List<string>();
                        List<(string, int)> subjects = item.Subjects ?? new List<(string, int)>();

                        Console.WriteLine(new string('=', 40));
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Name       : {firstName} {middleName} {lastName}");
                        Console.ResetColor();
                        Console.WriteLine($"Age        : {age}");
                        Console.WriteLine($"Class      : {classIn}");
                        Console.WriteLine($"Roll No.   : {rollNo}");
                        Console.WriteLine($"Address    : {address}");
                        Console.WriteLine($"Hobbies    : {string.Join(", ", hobbies)}");
                        Console.WriteLine($"Admission Date : {admissionDate} ");
                        Console.WriteLine($"Total Marks : {item.TotalMarks}");
                        Console.WriteLine("Subjects with Marks:");

                        foreach (var subject in subjects)
                        {
                            Console.WriteLine($"   - {subject.Item1}: {subject.Item2}");
                        }

                        Console.WriteLine(new string('=', 40));
                        Console.WriteLine();

                        if (duration)
                        {
                            Thread.Sleep(10000);
                        }
                    }

                    StudentUtility.ValidationMessage("All the students have been listed successfully");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Something Went Wrong in DisplayStudentInfo Function" + ex.Message);
            }
        }
    }

    public class SortToppoers : IComparer<Student>
    {
        public int Compare(Student a, Student b)
        {
            return Comparer<int>.Default.Compare(b.TotalMarks, a.TotalMarks);
        }
    }

    internal class StudentUtility
    {
        public static void ValidationMessage(string message)
        {
            Console.WriteLine(new string('=', 45));
            Console.WriteLine(message);
            Console.WriteLine(new string('=', 45));
        }

        public static int IntegerValidation(string message)
        {
            int value;

            while (true)
            {
                Console.WriteLine(message);
                string str = Console.ReadLine();

                if (int.TryParse(str, out value) && value >= 0 && str.All(char.IsDigit))
                {
                    break;
                }
                else
                {
                    ValidationMessage("Invalid - Input Should be Type of Int And Non Negative");
                }
            }
            return value;
        }

        public static string StringValidation(string message)
        {
            string str = "";

            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && input.All(char.IsLetter))
                {
                    str = input.ToLower();
                    break;
                }
                else
                {
                    ValidationMessage("Input cannot be empty, whitespace or Invalid");
                }
            }
            return str;
        }

        public static int ClassValidation(string message)
        {
            int value;

            while (true)
            {
                Console.WriteLine(message);
                string str = Console.ReadLine();

                if (int.TryParse(str, out value) && value >= 0 && str.All(char.IsDigit) && value >= 1 && value <= 12)
                {
                    break;
                }
                else
                {
                    ValidationMessage("Invalid - Input Should be Type of Int And Non Negative and Between 1 - 12");
                }
            }
            return value;
        }

        public static List<string> HobbyValidation(string message)
        {
            HashSet<string> hobbies = new HashSet<string>();
            List<string> allHobbies = new List<string>();

            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    hobbies = input.ToLower().Split(',')
                                   .Select(h => h.Trim())
                                   .Where(h => h.All(char.IsLetter))
                                   .ToHashSet();

                    int count = 0;
                    foreach (string item in hobbies)
                    {
                        allHobbies.Add(item);
                        count++;

                        if (count == 7)
                        {
                            break;
                        }
                    }

                    if (allHobbies.Count >= 1 && allHobbies.Count <= 7)
                    {
                        break;
                    }
                    else
                    {
                        ValidationMessage("All hobbies must contain only letters and should not be empty.");
                    }
                }
                else
                {
                    ValidationMessage("Input cannot be empty or whitespace.");
                }
            }
            return allHobbies;
        }

        public static string NameValidation(string message)
        {
            string str = "";

            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                if (input.Trim().Length == 0)
                {
                    break;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(input) && input.All(char.IsLetter))
                    {
                        str = input.ToLower().Trim();
                        break;
                    }
                    else
                    {
                        ValidationMessage("Input cannot be empty, whitespace or Invalid");
                    }
                }
            }
            return str;
        }

        public static string FullNameValidation(string message)
        {
            string str = "";

            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                if (input.Trim().Length == 0)
                {
                    break;
                }
                else
                {
                    string newStr = input.Replace(" ", "");
                    if (newStr.All(char.IsLetter))
                    {
                        str = input.ToLower().Trim();
                        break;
                    }
                    else
                    {
                        ValidationMessage("Input cannot be empty, whitespace or Invalid");
                    }
                }
            }
            return str;
        }
    }
}
