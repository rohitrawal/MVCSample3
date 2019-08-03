using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity1
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var ctx = new SchoolContext())
            {
                var stud = new Student() { StudentID = 1001, StudentName = "Bill" };

                ctx.students.Add(stud);
                ctx.SaveChanges();
            }
        }
    }
}