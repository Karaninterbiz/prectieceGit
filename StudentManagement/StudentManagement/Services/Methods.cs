using System;
using System.Collections.Generic;
using StudentManagementSystem.Enums;
using StudentManagementSystem.Models;
using StudentManagementSystem.Extensions;
using StudentManagementSystem.Common;

namespace StudentManagementSystem.Services
{
    public class Methods
    {
        public static void msg(string m)
        {
            Console.WriteLine(m);
        }
        public void AddStudent()
        {
            Student s = new();
            try
            {
                Console.Write("RollNo., FirstName, MiddleName, LastName, Age, Class(0-A,1-B,2-C), Address : ");
                var a = Console.ReadLine().Split();
                while (true)
                {
                    msg("Enter Roll Number : ");
                    if (int.TryParse(Console.ReadLine(), out int roll) && roll > 0)
                    {
                        s.RollNo = roll;
                        break;
                    }
                    else
                    {
                        msg("Invalid Roll Number! Please Enter Again...");
                    }
                }

                while (true)
                {
                    Console.Write("First Name: ");
                    string firstName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(firstName))
                    {
                        s.FirstName = firstName;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("First Name cannot be empty. Please enter again.");
                    }
                }
               

                Console.Write("Middle Name: ");
                s.MiddleName = Console.ReadLine();
                while (true)
                {
                    Console.Write("Last Name: ");
                    string lastName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(lastName))
                    {
                        s.LastName = lastName;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Last Name cannot be empty. Please enter again.");
                    }
                }

                while (true)
                {
                    msg("Enter Age: ");
                    if (int.TryParse(Console.ReadLine(), out int age) && age > 0)
                    {
                        s.Age = age;
                        break;
                    }
                    else
                    {
                        msg("Invalid Age! Please Enter Again...");
                    }
                }

                while (true)
                {
                    msg("Enter Class (0-First,1-Second,2-Third,3-Fourth,4-Fifth): ");
                    if (int.TryParse(Console.ReadLine(), out int cls) && cls >= 0 && cls <= 4)
                    {
                        s.Class = (StdClass)cls;
                        break;
                    }
                    else
                    {
                        msg("Invalid Class! Please Enter Again...");
                    }
                }

                Console.Write("Address: ");
                s.Address = Console.ReadLine();

                while (true)
                {
                    msg("Enter Total Subjects: ");
                    if (int.TryParse(Console.ReadLine(), out int sub) && sub > 0)
                    {
                        for (int i = 0; i < sub; i++)
                        {
                            string subName;
                            while (true)
                            {
                                msg($"Enter Subject {i + 1} Name: ");
                                subName = Console.ReadLine();

                                if (!string.IsNullOrWhiteSpace(subName))
                                {
                                    break;
                                }
                                else
                                {
                                    msg("Invalid Subject Name! Please Enter Again...");
                                }
                            }

                            int marks;
                            while (true)
                            {
                                msg($"Enter Marks of {subName}: ");
                                if (int.TryParse(Console.ReadLine(), out marks) && marks >= 0)
                                {
                                    break;
                                }
                                else
                                {
                                    msg("Invalid Marks! Please Enter Again...");
                                }
                            }

                            s.Subjects.Add(subName);
                            s.Marks[subName] = marks;
                        }
                        break; // Total Subject input successful — exit while loop
                    }
                    else
                    {
                        msg("Invalid Total Subjects! Please Enter Only Positive Integer Value...");
                    }
                }
                msg("Enter Hobby 1-7");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int hb) && hb > 0 && hb <= 7)
                    {
                        for (int i = 0; i < hb; i++)
                        {
                            msg($"Enter Hobby {i + 1}: ");
                            s.Hobbies.Add(Console.ReadLine());
                        }
                        break;
                    }
                    else
                    {
                        msg("Invalid Number! Please Enter Again...");
                    }
                }
                s.AddDate = DateTime.Now;
                DataStorage.students.Add(s);
                msg("Student Added Successfully...");
            }
            catch (Exception e)
            {
                msg("Wrong Data....");
            }
        }
        public void ShowAll()
        {
            if (DataStorage.students.Count == 0)
            {
                msg("No Students Found! Please Add The Student First...");
                return;
            }
            foreach (var s in DataStorage.students)
                msg($" Roll Number : {s.RollNo}\n First Name: {s.FirstName}\n Middle Name : {s.MiddleName}\n Last Name : {s.LastName}\n Age : {s.Age}\n Class : {s.Class}\n Address : {s.Address}\n TotalMarks:{s.TotalMarks()}\n Added:{s.AddDate}");
        }

        public void Filter()
        {
            Console.Write("Enter Name or Class(0/1/2) or Address or Hobby : ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                msg("Invalid Input! Please Enter Some Data...");
                return;
            }
            if (DataStorage.students.Count == 0)
            {
                msg("No Student Data Available! Please Add Student First...");
                return;
            }
            foreach (var s in DataStorage.students)
            {
                if (s.FirstName == input || s.MiddleName == input || s.LastName == input ||
                    s.Class.ToString() == input || s.Address == input || s.Hobbies.Contains(input))
                {
                    msg($"Found : {s.FirstName}");
                }
                else
                {
                    msg($"Invalid Input : {input}");
                }
                    
            }
        }
        public void AgeFilter()
        {
            if (DataStorage.students.Count == 0)
            {
                msg("No Student Data Available! Please Add Student First...");
                return;
            }
            foreach (var s in DataStorage.students)
                if (s.Age >= 15 && s.Age <= 25)
                    msg($"Age Match : {s.FirstName}");
        } 
        public void FindTopper()
        {
            if (DataStorage.students.Count == 0)
            {
                msg("No Student Data Available! Please Add Student First...");
                return;
            }
            foreach (var cls in Enum.GetValues(typeof(StdClass)))
            {
                Student top = null;
                foreach (var s in DataStorage.students)
                    if (s.Class == (StdClass)cls && (top == null || s.TotalMarks() > top.TotalMarks()))
                    {
                        top = s;
                    }
                if (top != null) msg($"Topper of {cls}: {top.FirstName}");
            }
        }
        public void NthTopper()
        {
            if (DataStorage.students.Count == 0)
            {
                msg("No Student Data Available! Please Add Student First...");
                return;
            }
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            DataStorage.students.Sort((x, y) => y.TotalMarks().CompareTo(x.TotalMarks()));
            if (n <= DataStorage.students.Count)
                msg($"Nth Topper Roll: {DataStorage.students[n - 1].RollNo}");
            else
                msg("Not enough students");
        }
    }
}
