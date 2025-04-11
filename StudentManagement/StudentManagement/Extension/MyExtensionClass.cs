using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Extensions
{
    public static class MyExtentionClass
    {
        public static int TotalMarks(this Student student)
        {
            int sum = 0;
            foreach (var item in student.Marks.Values)
            {
                sum += item;
            }
            return sum;
        }
    }
}
