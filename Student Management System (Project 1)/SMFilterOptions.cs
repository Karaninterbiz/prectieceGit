using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System__Project_1_
{
    public class SMFilterOptions
    {
        public static void FilterMenu()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("           Filter Menu                ");
            Console.WriteLine("======================================");
            Console.WriteLine("  11) Filter By Name");
            Console.WriteLine("  12) Filter By Age");
            Console.WriteLine("  13) Filter By Address");
            Console.WriteLine("  14) Filter By Roll No");
            Console.WriteLine("  15) Filter By Class");
            Console.WriteLine("  16) Filter By Hobbies");
            Console.WriteLine("  17) Filter By Subjects");
            Console.WriteLine("  18) Filter Student by Multiple Fields");
            Console.WriteLine("  29) Move Back to Home Menu -> ");
            Console.WriteLine("======================================");
        }


        public static List<Student> FilterByName(List<Student> students)
        {
            string nameFilter = StudentUtility.FullNameValidation("Enter Full Name to filter:");

            List<Student> filteredStudents = new List<Student>();

            foreach (var student in students)
            {
                string fullName = $"{student.FirstName} {student.MiddleName} {student.LastName}".ToLower();

                if (fullName.Contains(nameFilter))
                {
                    filteredStudents.Add(student);
                }
            }

            return filteredStudents;
        }
        // Filter by age
        public static List<Student> FilterByAge(List<Student> students)
        {


            int age = StudentUtility.IntegerValidation("Enter Age: (5 - 40)");

            while (!(age >= 5 && age <= 40))
            {
                StudentUtility.ValidationMessage("Age should be between 5 and 40.");
                age = StudentUtility.IntegerValidation("Enter Age: (5 - 40)");
            }

            List<Student> filteredStudents = new List<Student>();

            foreach (var student in students)
            {
                if ( student.Age == age)
                {
                    filteredStudents.Add(student);
                }
            }

            return filteredStudents;
        }

        // Filter by address
        public static List<Student> FilterByAddress(List<Student> students)
        {
            Console.WriteLine("Enter address to filter:");
            string addressFilter = Console.ReadLine().ToLower().Trim();

            List<Student> filteredStudents = new List<Student>();

            foreach (var student in students)
            {
                if (student.Address.ToLower().Contains(addressFilter))
                {
                    filteredStudents.Add(student);
                }
            }

            return filteredStudents;
        }
        // Filter by class (Grade)

       
        public static List<Student> FilterByClass(List<Student> students)
        {

            Console.WriteLine("Select Class:");
            foreach (var grade in Enum.GetValues(typeof(Grade)))
            {
                Console.Write($"{(int)grade}, ");
            }
            Console.WriteLine();
            int selectedClass = StudentUtility.ClassValidation("Enter the class number:");
            Grade grade1 = (Grade)selectedClass;

            List<Student> filteredStudents = new List<Student>();

            foreach (var student in students)
            {
                if (student.ClassIn == grade1)
                {
                    filteredStudents.Add(student);
                }
            }

            return filteredStudents;
        }

        public static List<Student> FilterByRollNo(List<Student> students)
        {
           
            int rollNo = StudentUtility.IntegerValidation("Enter roll number to filter:");

            List<Student> filteredStudents = new List<Student>();

            foreach (var student in students)
            {
                if (student.RollNo == rollNo)
                {
                    filteredStudents.Add(student);
                }
            }

            return filteredStudents;
        }

        public static List<Student> FilterByHobbies(List<Student> students)
        {
            int hobbyCount = StudentUtility.IntegerValidation("Enter Hobby Number : ");

            while (!(hobbyCount >= 1 && hobbyCount <= 7))
            {
                StudentUtility.ValidationMessage("Hobby Number should be between 1 to 7 .");
                hobbyCount = StudentUtility.IntegerValidation("Enter Hobby Number Again : ");
            }

            List<String> hobbyList = new List<String>(); 

            for(int i = 0; i< hobbyCount; i++)
            {
                string hobby = StudentUtility.StringValidation("Enter your hobby here : ");
                hobbyList.Add(hobby);
            }

            List<Student> filteredStudents = new List<Student>();

            foreach (var student in students)
            {
                bool flag = true;
                foreach (string str in hobbyList)
                {
                    if(!student.Hobbies.Contains(str)) 
                    {
                        flag = false; 
                        break; 
                    }
                }
                if (flag)
                {
                    filteredStudents.Add(student);
                }
            }

            return filteredStudents;
        }
        public static List<Student> FilterBySubjects(List<Student> students)
        {

            int totalSubject = StudentUtility.IntegerValidation("Ente number of subjects: (till 10)");

            while (!(totalSubject >= 1 && totalSubject <= 10))
            {
                StudentUtility.ValidationMessage("Only 10 subjects are allowed");
                totalSubject = StudentUtility.IntegerValidation("Enter the total number of subjects: (till 10)");
            }

            List<string> subjectList = new List<string>();

            for (int i = 0; i < totalSubject; i++)
            {
                Console.WriteLine("Subject No. : " + (i + 1));
                string subjectName = StudentUtility.StringValidation("Enter Subject Name:");
                subjectList.Add(subjectName.ToLower());
            }

            List<Student> filteredStudents = new List<Student>();

            foreach (var student in students)
            {

                bool flag = true;
                foreach (var subject in subjectList)
                {

                    if ( ! student.Subjects.Exists((sub) => sub.Item1 == subject))
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    filteredStudents.Add(student);
                }
            }

            return filteredStudents;
        }

        public static List<Student> FilterByAdmissionDate(List<Student> students)
        {
            Console.WriteLine("Enter admission date to filter:");
            string admissionDateFilter = Console.ReadLine().ToLower();

            List<Student> filteredStudents = new List<Student>();

            foreach (var student in students)
            {
                if (student.AdmissionDate.ToLower() == admissionDateFilter)
                {
                    filteredStudents.Add(student);
                }
            }

            return filteredStudents;
        }

        public static void FilterOptions(List<Student> students)
        {
            while (true)
            {

                Student obj = new Student();
                FilterMenu();
                string input = Console.ReadLine();
                int value;

                if (int.TryParse(input, out value))
                {
                    List<Student> filteredStudents = null;

                    switch (value)
                    {
                        case 11:
                            filteredStudents = FilterByName(students);
                            filteredStudents.DisplayStudentInfo(false);
                           break;
                        case 12:
                            filteredStudents = FilterByAge(students);
                            filteredStudents.DisplayStudentInfo(false);
                           break;
                        case 13:
                            filteredStudents = FilterByAddress(students);
                            filteredStudents.DisplayStudentInfo(false);
                           break;
                        case 14:
                            filteredStudents = FilterByRollNo(students);
                            filteredStudents.DisplayStudentInfo(false);
                           break;
                        case 15:
                            filteredStudents = FilterByClass(students);
                            filteredStudents.DisplayStudentInfo(false);
                             break;
                        case 16:
                            filteredStudents = FilterByHobbies(students);
                            filteredStudents.DisplayStudentInfo(false);
                             break;
                        case 17:
                            filteredStudents = FilterBySubjects(students);
                            filteredStudents.DisplayStudentInfo(false);
                             break;
                        case 18:
                            obj.FilterStudents(students);
                            break;
                        case 19:
                            Console.WriteLine("Exiting from filter Menu ......... ");
                            return;
                        default:
                           StudentUtility.ValidationMessage("Enter Valid Options");
                            break;
                    }
                }
                else
                {
                    StudentUtility.ValidationMessage("Please enter a valid input of Type Integer");
                }
            }
        }
    }
}
