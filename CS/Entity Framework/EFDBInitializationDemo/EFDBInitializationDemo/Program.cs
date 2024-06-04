using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SchoolDataLayer;
using SchoolDomainClasses;
using System.Data.Entity;

namespace EFSimpleCodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var ctx = new SchoolDBContext())
            {
                //Student stud = new Student() { StudentName = "New Student" };
                //ctx.Students.Add(stud);
                //ctx.SaveChanges();
                Student stud1 = ctx.Students.FirstOrDefault<Student>();
                Standard std = ctx.Standards.FirstOrDefault<Standard>();

            }

            Console.WriteLine("Code first demo successful");
            Console.ReadKey();
        }
    }
}
