using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.SelfReferencing;

namespace LinqCookBook.SelfReferencing
{
    public class SFTPHExample
    {
        public static void Run()
        {
            Example1();
           // Example2();
        }

      

        private static void Example1()
        {
            var db = new SFTPHEntities();
            var president = db.Employees
                              .Include("Employees.Employees.Employees")
                              .Where(e => e.ReportsTo == null).First();

            Console.WriteLine("President:{0} Type:{1}", president.Name, president.GetType().Name);
            var manager = president.Employees.First();
            Console.WriteLine(" Manager:{0} Type:{1}", manager.Name, manager.GetType().Name);
            var supervisor = manager.Employees.First();
            Console.WriteLine("  Supervisor:{0} Type:{1}", supervisor.Name, supervisor.GetType().Name);
            foreach (var agent in supervisor.Employees)
            {
                Console.WriteLine("   Agent:{0} Type:{1}", agent.Name, agent.GetType().Name);
            }
        }
    }
}
