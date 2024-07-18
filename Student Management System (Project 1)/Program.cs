using System;
using System.Collections.Generic;

namespace Student_Management_System__Project_1_
{
    internal class Program
    {
        public static void HomePage()
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine("          Student Menu          ");
            Console.WriteLine(new string('=', 40));
            Console.WriteLine("1) Insert Students");
            Console.WriteLine("2) Filter Students");
            Console.WriteLine("3) Get Topper Students");
            Console.WriteLine("4) Get N Topper Students");
            Console.WriteLine("5) Get Student Filter by Age");
            Console.WriteLine("6) Display Students");
            Console.WriteLine("7) Display Students in 10 seconds");
            Console.WriteLine("8) Exit");
            Console.WriteLine(new string('=', 40));
        }

        static void Main(string[] args)
        {
            Student obj = new Student();
            List<Student> students = new List<Student>
            {
                new Student
                {
                    FirstName = "alice",
                    MiddleName = "a",
                    LastName = "smith",
                    Age = 20,
                    Address = "123 main st",
                    RollNo = 1,
                    ClassIn = Grade.Grade10,
                    AdmissionDate = "20/09/2024",
                    Hobbies = new List<string> { "reading", "swimming" },
                    Subjects = new List<(string, int)> { ("math", 90), ("science", 85) }
                },
                new Student
                {
                    FirstName = "bob",
                    MiddleName = "b",
                    LastName = "johnson",
                    Age = 30,
                    Address = "456 oak st",
                    RollNo = 2,
                    ClassIn = Grade.Grade10,
                    AdmissionDate = "29/01/2024",
                    Hobbies = new List<string> { "gaming", "basketball" },
                    Subjects = new List<(string, int)> { ("math", 80), ("science", 76) }
                },
                new Student
                {
                    FirstName = "charlie",
                    MiddleName = "c",
                    LastName = "williams",
                    Age = 10,
                    Address = "789 pine st",
                    RollNo = 3,
                    ClassIn = Grade.Grade11,
                    AdmissionDate = "02/06/2024",
                    Hobbies = new List<string> { "drawing", "music" },
                    Subjects = new List<(string, int)> { ("math", 95), ("science", 89) }
                },
                new Student
                {
                    FirstName = "david",
                    MiddleName = "d",
                    LastName = "brown",
                    Age = 25,
                    Address = "321 maple st",
                    RollNo = 4,
                    ClassIn = Grade.Grade12,
                    AdmissionDate = "22/03/2024",
                    Hobbies = new List<string> { "photography", "reading" },
                    Subjects = new List<(string, int)> { ("math", 90), ("science", 85) }
                },
            };

            try
            {
                Console.WriteLine("Welcome to the Student Management System");

                while (true)
                {
                    HomePage();
                    string input = Console.ReadLine();
                    int value;

                    if (int.TryParse(input, out value))
                    {
                        switch (value)
                        {
                            case 1:
                                obj.InsertStudent(students);
                                break;
                            case 2:
                                SMFilterOptions.FilterOptions(students);
                                break;
                            case 3:
                                obj.FindTopperOfClass(students);
                                break;
                            case 4:
                                obj.GetTopNStudents(students);
                                break;
                            case 5:
                                obj.StudentsAgeBetween(students);
                                break;
                            case 6:
                                students.DisplayStudentInfo(false);
                                break;
                            case 7:
                                students.DisplayStudentInfo(true);
                                break;
                            case 8:
                                Console.WriteLine("Exiting .......... ");
                                return;
                            default:
                                Console.Clear();
                                StudentUtility.ValidationMessage("Please Enter Valid Options");
                                continue;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        StudentUtility.ValidationMessage("Please enter a valid input of Type Integer");
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Something Went Wrong in Home Page : " + Ex.Message);
            }
        }
    }
}
