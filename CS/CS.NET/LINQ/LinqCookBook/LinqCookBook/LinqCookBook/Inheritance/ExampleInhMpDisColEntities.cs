using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.Extensions;
using MapToDisColumn;

namespace LinqCookBook.Inheritance
{
    public class ExampleInhMpDisColEntities
    {
        static void CleanUp()
        {
            var db = new InhMpDisColEntities();
            var cmd = db.CreateStoreCommand("delete Employees;delete Salary;");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }


        public static void Run()
        {
            CleanUp();
            var db = new InhMpDisColEntities();
            var employee = new Employee { Name = "Zeeshan" };
            employee.Salaries.Add(new HistoricalSalary
            {
                Income = 95000,
                StartDate = new DateTime(2005, 12, 1),
                EndDate = new DateTime(2007, 1, 1)
            });
            employee.Salaries.Add(new CurrentSalary { Income = 100000, StartDate = DateTime.Now });
            db.AddToEmployees(employee);
            db.SaveChanges();

            var db2 = new InhMpDisColEntities();
            var emp = db2.Employees.Include("Salaries").First();
            foreach (var salary in emp.Salaries)
            {
                Console.WriteLine("Sal {0} Type {1}",salary.Income,salary.GetType().Name);
            }
        }
    }
}
