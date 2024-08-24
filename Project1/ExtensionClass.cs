using System;
using System.Collections.Generic;
using System.Threading;
 
namespace StudentManaGE

{

    public static class StudentExtensions

    {
        public static void FindStudentEvery10Seconds(this List<Students> students)

        {
            foreach (var student in students)

            {
 
                Console.WriteLine($"First Name: {student.FirstName}, Middle Name: {student.MiddleName}, Last Name: {student.LastName}, Age: {student.Age}, Roll Number: {student.RollNumber}, Maths Marks: {student.SubMaths}, English Marks: {student.SubEnglish}, Hindi Marks: {student.SubHindi}, Address: {student.Address}");
 
                Thread.Sleep(10000);

            }

        }

    }

}
 