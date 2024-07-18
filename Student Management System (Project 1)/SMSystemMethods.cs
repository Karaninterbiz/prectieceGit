using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System__Project_1_
{
    // delegate 
    public delegate void CalculateTotalMarksDelegate(ref List<Student> students);

    // partial class 
    public partial class Student
    {
     
        // this method will calculate the sum of subject and insert in class Field TotalMarks
        public static void CalculateTotalMarks(ref List<Student> students)
        {
            foreach (Student student in students)
            {
                int sum = 0;
                foreach (var item in student.Subjects)
                {
                    sum += item.Item2;
                }
                student.TotalMarks = sum;
            }
        }

        // This method will take user input based on condition 
        public static Student TakeStudentInfoInput(bool validation)
        {
            try
            {
                string optional = validation ? "(Optional)" : "";
                Student student = new Student();


                // if condition will excecute if validation is false    
                // this part will work for inserting student into the Collection
                if (!validation)
                {
                    student.FirstName = StudentUtility.StringValidation("Enter First Name:");
                    student.MiddleName = StudentUtility.StringValidation("Enter Middle Name:");
                    student.LastName = StudentUtility.StringValidation("Enter Last Name:");
                    Console.WriteLine("Enter Address:");
                    string addressStr = Console.ReadLine();

                    while(addressStr.ToLower().Trim().Length == 0)
                    {
                        Console.WriteLine("Enter Address: Again");
                         addressStr = Console.ReadLine();
                    }
                    student.Address = addressStr.ToLower().Trim();

                    // Enums as classes 

                    Console.WriteLine("Select Class:");
                    foreach (var grade in Enum.GetValues(typeof(Grade)))
                    {
                        Console.Write($"{(int)grade} ");
                    }
                    Console.WriteLine();
                    int selectedClass = StudentUtility.ClassValidation("Enter the class number:");
                    student.ClassIn = (Grade)selectedClass;

                    student.Hobbies = StudentUtility.HobbyValidation("Enter Hobbies (comma separated):");

                    student.Age = StudentUtility.IntegerValidation("Enter Age: (5 - 40)");

                    while (!(student.Age >= 5 && student.Age <= 40))
                    {
                        StudentUtility.ValidationMessage("Age should be between 5 and 40.");
                        student.Age = StudentUtility.IntegerValidation("Enter Age: (5 - 40)");
                    }

                    student.RollNo = StudentUtility.IntegerValidation("Enter Roll Number:");

                    int totalSubject = StudentUtility.IntegerValidation("Enter the total number of subjects: (till 10)");

                    while (!(totalSubject >= 1 && totalSubject <= 10))
                    {
                        StudentUtility.ValidationMessage("Only 10 subjects are allowed");
                        totalSubject = StudentUtility.IntegerValidation("Enter the total number of subjects: (till 10)");
                    }

                    List<(string, int)> ls = new List<(string, int)>();

                    for (int i = 0; i < totalSubject; i++)
                    {
                        Console.WriteLine("Subject No. : " + (i + 1));
                        string subjectName = StudentUtility.StringValidation("Enter Subject Name:");

                        int subMarks = StudentUtility.IntegerValidation("Enter Subject Marks:");
                        while (!(subMarks >= 0 && subMarks <= 100))
                        {
                            StudentUtility.ValidationMessage("Marks should between 0 - 100");
                             subMarks = StudentUtility.IntegerValidation("Enter Subject Marks Again:");
                        }
                        ls.Add((subjectName.ToLower(), subMarks));
                    }

                    student.Subjects = ls;
                }
                else
                {

                    // this is multifield Filtering methods and codition are placed according to the fields

                    student.FirstName = StudentUtility.NameValidation($"Enter First Name:{optional}");

                    student.MiddleName = StudentUtility.NameValidation($"Enter Middle Name:{optional}");

                    student.LastName = StudentUtility.NameValidation($"Enter Last Name:{optional}");

                    while (true)
                    {
                       
                            Console.WriteLine($"Enter Age: under (5-40){optional}");
                            string strAge = Console.ReadLine();

                            if (strAge.Trim().Length == 0)
                            {
                                student.Age = -1;
                                break;
                            }
                            else
                            {
                                int value;

                                if (!int.TryParse(strAge, out value) || !strAge.All(char.IsDigit) || value < 1 || value > 40)
                                {
                                    StudentUtility.ValidationMessage("Age should be between 5 and 40.");
                                }
                                else
                                {
                                    student.Age = Convert.ToInt32(strAge);
                                    break;
                                }
                            }
                      
                    }
                         
                    Console.WriteLine($"Enter Address:{optional}");
                    student.Address = Console.ReadLine();

                    Console.WriteLine($"Enter Roll Number{optional}");
                    string RollNoStr = Console.ReadLine();

                    if (RollNoStr.Trim().Length == 0)
                    {
                        student.RollNo = -1;
                    }
                    else
                    {
                        int value;
                        if(int.TryParse(RollNoStr , out value))
                        {
                            student.RollNo = Convert.ToInt32(RollNoStr);
                        }
                        else
                        {
                            StudentUtility.ValidationMessage("Plese Enter Roll No. of Type Integer");
                            student.RollNo = StudentUtility.IntegerValidation($"Enter Roll Number {optional}");
                        }
                       
                    }

                    Console.WriteLine("Select Class:");
                    foreach (var grade in Enum.GetValues(typeof(Grade)))
                    {
                        Console.Write ($"{(int)grade}, ");
                    }
                    Console.WriteLine();

                    string classStr = Console.ReadLine();

                    if(classStr.Trim().Length == 0)
                    {
                        student.ClassIn = Grade.Grade0;
                    }
                    else
                    {
                        if (int.TryParse(classStr, out int value) && (value >= 1 && value  <= 12))
                        {
                            student.ClassIn = (Grade)value;
                        }
                        else
                        {
                            StudentUtility.ValidationMessage("Enter Valid class listed above");
                            int selectedClass = StudentUtility.ClassValidation("Enter the class number:");
                            student.ClassIn = (Grade)selectedClass;
                        }
                    }
                   

                    Console.WriteLine($"Enter Hobbies (comma separated):{optional}");
                    string hobbiesInput = Console.ReadLine();                  

                    if (hobbiesInput.Trim().Length > 0)
                    {

                        string newStr = hobbiesInput.Replace(",", "").Replace(" ", "").ToLower().Trim();

                        if (!string.IsNullOrWhiteSpace(newStr) && newStr.All(char.IsLetter))
                        {
                            student.Hobbies = hobbiesInput.ToLower().Split(',').Select(h => h.Trim()).Where(h => h.All(char.IsLetter))
                                   .ToList();
                        }
                        else
                        {
                            student.Hobbies = StudentUtility.HobbyValidation("Enter Hobbies (comma separated): (Optional)");
                        }
                    }
                }

                return student;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong in {TakeStudentInfoInput}" + ex.Message);
            }

            Student st = new Student();
            return st;
        }

        public void InsertStudent(List<Student> students)
        {
            try
            {

                // this method will insert student into the collection
                Student studentInfo = TakeStudentInfoInput(false);

                students.Add(studentInfo);

                StudentUtility.ValidationMessage("Student Record has been Saved");
            }
            catch (Exception ex)
            {
                throw new Exception("Something Went Wrong in InsertStudent Function" + ex.Message);
            }

        }

        public  void FilterStudents(List<Student> students)
        {
            try
            {
                
                // this method is for filtering and meant for the multiple filtering together
                Student studentInfo = TakeStudentInfoInput(true);

                List<string> ls = new List<string>();

                Console.WriteLine("Enter No. of Subjects at most 10: ");
                string totalSubStr = Console.ReadLine();

                // here i am taking the number of subject for filtering
                int totalSubject = 0;

                if (totalSubStr.Trim().Length > 0 )
                {
                    while (true)
                    {
                        if (int.TryParse(totalSubStr, out totalSubject) && totalSubject >= 0 && (totalSubject >= 1 && totalSubject <= 10))
                        {
                            break;
                        }
                        else
                        {
                            StudentUtility.ValidationMessage("Please Enter a Integer Type value ");
                            Console.WriteLine("Enter No. of Subjects at most 10: ");
                            totalSubStr = Console.ReadLine();
                        }                       
                    }   
                }
                
                for (int i = 0; i < totalSubject; i++)
                {
                    string subjectName = StudentUtility.StringValidation("Enter Subject Name : ");
                    ls.Add(subjectName.ToLower().Trim());
                }

                List<Student> filteredStudent = new List<Student>();


                string str1 = "";
                for (int i = 1; i <= 7; i++)
                {
                    if (studentInfo[i].Trim() == "-1")
                    {
                        str1 = str1 + "";
                    }
                    else
                    {
                        string s = studentInfo[i].Trim();
                        str1 = str1 + s;
                    }
                }

                // from here the actual logic will start taking for multiple filtering

                foreach (var item in students)
                {
                    string str2 = "";
                    for (int i = 1; i <= 7; i++)
                    {

                        if (studentInfo[i].Trim() == "-1")
                        {
                            str2 = str2 + "";
                        }
                        else
                        {
                            string s = studentInfo[i].Trim();
                            if (s.Length > 0)
                            {
                                str2 = str2 + item[i].Trim();
                            }
                        }
                    }

                    bool checkHobbies = true;
                    bool checkSubject = true;

                    foreach (string str in studentInfo.Hobbies)
                    {
                        if (!item.Hobbies.Contains(str))
                        {
                            checkHobbies = false;
                            break;
                        }
                    }

                    foreach (string strSub in ls)
                    {
                        if (!item.Subjects.Exists(s => s.Item1 == strSub))
                        {
                            checkSubject = false;
                            break;
                        }
                    }

                    str1 = str1.ToLower();
                    str2 = str2.ToLower();

                    if (str1.Equals(str2) && checkHobbies && checkSubject)
                    {
                        filteredStudent.Add(item);
                    }
                    //Console.WriteLine($"String 1 : {str1} , String 2 : {str2}");
                }

                Console.WriteLine("this are the filtered students : ");
                filteredStudent.DisplayStudentInfo(false);
            }
            catch (Exception ex)
            {
                throw new Exception("Something Went Wrong in FilterStudents Function" + ex.Message);
            }
        }

        // Method to get the Topers
        public void FindTopperOfClass(List<Student> students)
        {
            try
            {

                // this method will first calculate the totalmarks of student then will sort basis on a totalMarks then list down all the toppers with the help of delegate

                List<Student> topperOfClass = SMFilterOptions.FilterByClass(students);

                Console.WriteLine("Filtered Student size is : " + topperOfClass.Count);

                CalculateTotalMarksDelegate del = new CalculateTotalMarksDelegate(CalculateTotalMarks);
                del(ref students);

                topperOfClass.Sort(new SortToppoers());

                List<Student> toppers = new List<Student>();
                HashSet<int> topMarks = new HashSet<int>();

                foreach (var item in topperOfClass)
                {
                    if (topMarks.Count < 3 || topMarks.Contains(item.TotalMarks))
                    {
                        if (topMarks.Count < 3)
                        {
                            topMarks.Add(item.TotalMarks);
                        }
                        toppers.Add(item);
                    }
                    else
                    {
                        break;
                    }
                }

                toppers.DisplayStudentInfo(false);
            }
            catch (Exception ex)
            {
                throw new Exception("Something Went Wrong in FindTopperOfClass Function" + ex.Message);
            }
        }


        // Method to get the Topers
        public void GetTopNStudents(List<Student> students)
        {

            // this method will also first calculate the totalmarks of student then will sort basis on a totalMarks then list down all the toppers with the help of delegate

            List<Student> topperOfClass = SMFilterOptions.FilterByClass(students);

            CalculateTotalMarksDelegate del = new CalculateTotalMarksDelegate(CalculateTotalMarks);
            del(ref topperOfClass);

            int N = StudentUtility.IntegerValidation("Enter size of N : ");

            // Sort students by TotalMarks in descending order
            topperOfClass.Sort(new SortToppoers());

            List<Student> toppers = new List<Student>();
            HashSet<int> topMarks = new HashSet<int>();

            
            //students.Sort((a, b) => b.TotalMarks.CompareTo(a.TotalMarks));

            foreach (var item in topperOfClass)
            {
                if (topMarks.Count < N || topMarks.Contains(item.TotalMarks))
                {
                    if (topMarks.Count < N)
                    {
                        topMarks.Add(item.TotalMarks);
                    }
                    toppers.Add(item);
                }
                else
                {
                    break;
                }
            }

            toppers.DisplayStudentInfo(false);
        }


        public void StudentsAgeBetween(List<Student> students)
        {
            try
            {

                int lowAgeRange = StudentUtility.IntegerValidation("Enter Student Low Age Range");

                while( ! (lowAgeRange >= 1 && lowAgeRange <= 100))
                {

                }

                int highAgeRange = StudentUtility.IntegerValidation("Enter Student High Age Range");

                List<Student> studentList = new List<Student>();

                foreach (Student item in students)
                {
                    if (item.Age >= lowAgeRange && item.Age <= highAgeRange)
                    {
                        studentList.Add(item);
                    }
                }

                StudentUtility.ValidationMessage($"Students Whose Age is between {lowAgeRange} to {highAgeRange} are {studentList.Count}");
                studentList.DisplayStudentInfo(false);
            }
            catch (Exception ex)
            {
                throw new Exception("Something Went Wrong in StudentsAgeBetween Function" + ex.Message);
            }
        }
    }
}
