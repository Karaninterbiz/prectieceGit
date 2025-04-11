using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Enums;
namespace StudentManagementSystem.Models

{
    public class Student
    {
        public string FirstName, LastName, MiddleName, Address;
        public int RollNo;
        public int Age;
        public StdClass Class;
        public List<string> Subjects = new List<string>();
        public Dictionary<string, int> Marks = new Dictionary<string, int>();
        public List<string> Hobbies = new List<string>();
        public DateTime AddDate;
    }
}
