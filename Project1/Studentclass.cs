using System;
using System.Collections.Generic;
namespace StudentManaGE
{
    public class Students
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int RollNumber { get; set; }
        public List<string> Hobbies { get; set; } 
        public int SubMaths { get; set; }
        public ClassNumber Class { get; set; }
        public int SubEnglish { get; set; }
        public int SubHindi { get; set; }
        public string Address { get; set; }
    }
}