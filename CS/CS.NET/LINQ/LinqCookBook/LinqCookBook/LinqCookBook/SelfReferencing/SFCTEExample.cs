using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFCTE;

namespace LinqCookBook.SelfReferencing
{
    public class SFCTEExample
    {
        public static void Run()
        {
            Example1();
        }

        private static void Example1()
        {
            var db = new SFCTEPHEntities();
            var president = db.Employees.First(e => e.ReportsTo == null);
            var emps = db.GetSubEmployees(president.EmployeeID);
            Console.WriteLine("All Employees working under president\r\n");
            foreach (var emp in emps)
            {
                Console.WriteLine("Name:{0} Type:{1}", emp.Name, emp.GetType().Name);
            }
        }
    }
}
