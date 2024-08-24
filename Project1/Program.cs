using System;
using System.Collections.Generic;
using System.Numerics;

namespace StudentManaGE
{
  
  
    public delegate int GetAllStudentsDelegate();

    public class Program
    {
        static List<Students> students = new List<Students>();

        public static void Main(string[] args)
        {
            GetAllStudentsDelegate getAllStudentsDelegate = GetAllStudents;

            while (true)
            {
                Console.WriteLine("Student management system");
                Console.WriteLine("1. Add student to system");
                Console.WriteLine("2. Get all the students with all details");
                Console.WriteLine("3. Filter student by details");
                Console.WriteLine("4. Find student age between 15 to 25");
                Console.WriteLine("5. Find topper");
                Console.WriteLine("6. Roll number of student at Nth position");
                Console.WriteLine("7. Find all the classes where the student belongs to every 10 seconds");
                Console.WriteLine("8. Exit");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddStudent();
                            break;
                        case 2:
                            int count = getAllStudentsDelegate();
                           
                            break;
                        case 3:
                            FilterStudentsByDetails();
                            break;
                        case 4:
                            FindStudentsByAge();
                            break;
                        case 5:
                            FindTopper();
                            break;
                        case 6:
                            RollNumberAtNthPosition();
                            break;
                        case 7:
                            FindClassesEvery10Seconds();
                            break;
                        case 8:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }



        public static void AddStudent()
        {
            Students student = new Students();

            {


                Console.WriteLine("Enter First Name:");
                student.FirstName = Console.ReadLine();
                try
                {

                    if (string.IsNullOrWhiteSpace(student.FirstName))
                    {
                        Console.WriteLine("First Name cannot be empty.");
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("error: " + ex.Message);
                }
            }

            {
                Console.WriteLine("Enter Middle Name:");
                student.MiddleName = Console.ReadLine();
                try
                {
                   
                   

                    if (string.IsNullOrEmpty(student.MiddleName))
                    {
                       
                            {
                                Console.WriteLine(" Middle Name cannot be empty.");
                                return;
                            }
                        }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected error: " + ex.Message);
                }
            }


            try
            {
                Console.WriteLine("Enter Last Name:");
                student.LastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(student.LastName))
                {
                    Console.WriteLine("Last Name cannot be empty.");
                    return;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex.Message);
            }


            try
            {
                Console.WriteLine("Enter Age:");
                student.Age = int.Parse(Console.ReadLine());


                if (student.Age <= 0 || student.Age > 30)
                {
                    Console.WriteLine("Enter age.");
                    return;
                }
            }
           
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return;
            }


            try
            {


                Console.WriteLine("Enter Roll Number:");
                student.RollNumber = int.Parse(Console.ReadLine());
                if (student.RollNumber <= 0)
                    Console.WriteLine("Roll Number must be a positive number.");
            }
           
           
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return;
            }


            try
            {
                Console.WriteLine("Enter Maths subject marks (0to100):");
                student.SubMaths = int.Parse(Console.ReadLine());


                if (student.SubMaths < 0 || student.SubMaths > 100)
                {
                    Console.WriteLine("Enter valid marks between 0 to 100");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return;
            }


            try
            {
                Console.WriteLine("Enter English subject marks (0-100):");
                student.SubEnglish = int.Parse(Console.ReadLine());
                if (student.SubEnglish < 0 || student.SubEnglish > 100)
                {
                    Console.WriteLine("Enter vslid msrks between 0 to 100");
                }
            }
            
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

                return;
            }


            try
            {
                Console.WriteLine("Enter Hindi subject marks (0 to100):");

                student.SubHindi = int.Parse(Console.ReadLine());

                if (student.SubHindi < 0 || student.SubHindi > 100)
                {
                    Console.WriteLine("Enter vslid marks between 0 to 100");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return;
            }


            Console.WriteLine("Enter Address:");
            student.Address = Console.ReadLine();

            Console.WriteLine("Enter Class Number (1-12):");
            { 
            string eclass = Console.ReadLine();
            if (int.TryParse(Console.ReadLine(), out int eNum))
            {
                if (Enum.IsDefined(typeof(ClassNumber), eNum))
                {
                    ClassNumber myC = (ClassNumber)eNum;
                }
            }
        }



            try
            {
                Console.WriteLine("Enter number of Hobbies (1-7):");
                int numHobbies = int.Parse(Console.ReadLine());
                if (numHobbies < 1 || numHobbies > 7)
                {
                    Console.WriteLine("hobbies can be atleast 1 and atmost 7");

                }



                student.Hobbies = new List<string>();
                for (int i = 0; i < numHobbies; i++)
                {
                    Console.WriteLine("Enter hobby:");
                    string hobby = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(hobby))
                    {
                        Console.WriteLine ("Hobby can't be empty.");
                    }
                        student.Hobbies.Add(hobby);
                }
            }
           
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return;
            }

            students.Add(student);
            Console.WriteLine("Student added successfully.");
        }


        public static int GetAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students to display.");
                return 0;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"First Name: {student.FirstName}, Middle Name: {student.MiddleName}, Last Name: {student.LastName}, Age: {student.Age}, Roll Number: {student.RollNumber}, " +
                                  $"Maths Marks: {student.SubMaths}, English Marks: {student.SubEnglish}, Hindi Marks: {student.SubHindi}, Address: {student.Address}, " +
                                  $"Class: {student.Class}, Hobbies: {string.Join(", ", student.Hobbies)}");
            }

            return students.Count;
        }

        public static void FilterStudentsByDetails()
        {
            Console.WriteLine("Enter your filter choice:");
            Console.WriteLine("1. Filter by first name");
            Console.WriteLine("2. Filter by middle name");
            Console.WriteLine("3. Filter by last name");
            Console.WriteLine("4. Filter by address");
            Console.WriteLine("5. Filter by hobbies");

            int c;
            if (int.TryParse(Console.ReadLine(), out c))
            {
                switch (c)
                {
                    case 1:
                        Console.WriteLine("Enter first name:");
                        string fname = Console.ReadLine();
                        foreach (var student in students)
                        {
                            if (student.FirstName == fname)
                            {
                                Console.WriteLine($"Student found: {student.FirstName} {student.MiddleName} {student.LastName}");
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter middle name:");
                        string mname = Console.ReadLine();
                        foreach (var student in students)
                        {
                            if (student.MiddleName == mname)
                            {
                                Console.WriteLine($"Student found: {student.FirstName} {student.MiddleName} {student.LastName}");
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter last name:");
                        string lname = Console.ReadLine();
                        foreach (var student in students)
                        {
                            if (student.LastName == lname)
                            {
                                Console.WriteLine($"Student found: {student.FirstName} {student.MiddleName} {student.LastName}");
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter address:");
                        string adrs = Console.ReadLine();
                        foreach (var student in students)
                        {
                            if (student.Address == adrs)
                            {
                                Console.WriteLine($"Student found with address: {student.FirstName} {student.MiddleName} {student.LastName}, Address: {student.Address}");
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter hobby:");
                        string hobby = Console.ReadLine();
                        foreach (var student in students)
                        {
                            if (student.Hobbies.Contains(hobby))
                            {
                                Console.WriteLine($"Student found with hobby: {student.FirstName} {student.MiddleName} {student.LastName}, Hobby: {hobby}");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Option not available.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        public static void FindStudentsByAge()
        {
            foreach (var student in students)
            {
                if (student.Age >= 15 && student.Age <= 25)
                {
                    Console.WriteLine($"Student Name: {student.FirstName} {student.LastName}, Age: {student.Age}");
                }
            }
        }

        public static void FindTopper()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.");
                return;
            }
            
                Students topper = students[0];
                int highestTotalMarks = topper.SubMaths + topper.SubEnglish + topper.SubHindi;

                foreach (var student in students)
                {
                 
                    int totalMarks = student.SubMaths + student.SubEnglish + student.SubHindi;

                 
                    if (totalMarks > highestTotalMarks)
                    {
                        highestTotalMarks = totalMarks;
                        topper = student;
                    }
                }

            if (topper != null)
            {
                Console.WriteLine($"Topper: {topper.FirstName} {topper.MiddleName} {topper.LastName}, Total Marks: {highestTotalMarks}");
               
            }


        }

        public static void RollNumberAtNthPosition()
        {
            Console.WriteLine("Enter Nth position:");
            int n;
            if (int.TryParse(Console.ReadLine(), out n) && n > 0 && n <= students.Count)
            {
                Students student = students[n - 1];
                Console.WriteLine($"Student at position {n} has Roll Number: {student.RollNumber}, Firstname: { student.FirstName} , Middlename: {student.MiddleName} , Lastname {student.LastName}");
                
            }
            else
            {
                Console.WriteLine("Invalid position.");
            }
        }


        public static void FindClassesEvery10Seconds()
        {
            students.FindStudentEvery10Seconds();

        }
    }
}
