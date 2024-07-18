using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System__Project_1_
{
    public enum Grade
    {
        Grade0 = 0,
        Grade1 = 1,
        Grade2,
        Grade3,
        Grade4,
        Grade5,
        Grade6,
        Grade7,
        Grade8,
        Grade9,
        Grade10,
        Grade11,
        Grade12
    }

    public partial class Student
    {

        // Properties 
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int TotalMarks { get; set; }
        public string Address { get; set; }
        public int RollNo { get; set; }
        public Grade ClassIn { get; set; }

        public string AdmissionDate { get; set; } 
        public List<string> Hobbies { get; set; }
        public List<(string, int)> Subjects { get; set; }



        // default Constructor
        public Student()
        {
            FirstName = "";
            MiddleName = "";
            LastName = "";
            Age = 0;
            TotalMarks = 0;
            Address = "";
            RollNo = -1;
            AdmissionDate = "";
            Hobbies = new List<string>();
            Subjects = new List<(string, int)>();
        }

        // Parameterized Constructor
        public Student(string FirstName, string MiddleName, string LastName, int Age, string Address, int RollNo,
                       Grade ClassIn, List<string> Hobbies, List<(string, int)> Subjects , string AdmissionDate)
        {
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.Age = Age;
            this.Address = Address;
            this.RollNo = RollNo;
            this.ClassIn = ClassIn;
            this.Subjects = Subjects;
            this.AdmissionDate = AdmissionDate;
            
            int marks = 0;

            if (Hobbies.Count <= 7)
            {
                this.Hobbies = Hobbies;
            }
            else
            {
                throw new Exception("Only 7 Hobbies are allowed");
            }
        }

        // Indexers 
        public string this [int index]
        {
            get
            {
                if(index == 1)
                {
                    return FirstName;
                }
                else if(index == 2)
                {
                    return MiddleName;
                }
                else if (index == 3)
                {
                    return LastName;
                }
                else if (index == 4)
                {
                    return Convert.ToString(Age);
                }
                else if (index == 5)
                {
                    return Address;
                }
                else if (index == 6)
                {
                    return Convert.ToString(RollNo);
                }
                else if (index == 7)
                {
                    int classNum = (int)ClassIn;
                    if(classNum == 0)
                    {
                        classNum = -1;
                        return classNum.ToString();
                    }
                    return classNum.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
