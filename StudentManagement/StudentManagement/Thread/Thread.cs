using StudentManagementSystem.Common;
using StudentManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace StudentManagementSystem.Thread
{
    public class ThreadClass
    {
       public  static void AutoDisplayThread()
       {

            new System.Threading.Thread(() =>
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(10000);
                    foreach (var s in DataStorage.students)
                    {
                        Methods.msg($"Class : {s.Class}");
                    }
                }
            }).Start();
       }
    }
}
