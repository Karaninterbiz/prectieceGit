using System;
using System.Threading;
using StudentManagementSystem.Services;
using StudentManagementSystem.Common;
using StudentManagementSystem.Models;
using StudentManagementSystem.Thread;

namespace StudentManagementSystem.Program
{
    public class MainMethod
    {

        static void Main()
        {
            Methods p = new Methods();

            ThreadClass.AutoDisplayThread();

            while (true)
            {
                Console.WriteLine("\n1.Add \n2.ShowAll \n3.Filter \n4.Age Filter(15-25) \n5.Find Topper \n6.Nth Topper \n7.Exit");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Methods.msg("Invalid Input! Please Enter Again...");
                    continue;
                }

                switch (choice)
                {
                    case 1: p.AddStudent(); break;
                    case 2: p.ShowAll(); break;
                    case 3: p.Filter(); break;
                    case 4: p.AgeFilter(); break;
                    case 5: p.FindTopper(); break;
                    case 6: p.NthTopper(); break;
                    case 7: Environment.Exit(0); break;
                    default: Methods.msg("Invalid Choice! Please Enter Again..."); break;
                }
            }
        }
    }
}
