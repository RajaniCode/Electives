using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.LS.TablePerType;

namespace ConsoleLinqToSql.TablePerType
{
    public class TablePerTypeExample
    {
        public static void InsertEmployees()
        {
            var hourlyemp = new HourlyEmployee
            {
                Email = "alis@gmail.com",
                Hours = 40,
                Rate = 50,
                Name = "Alis"
            };
            var salaryemp = new SalariedEmployee
            {
                Email = "Sam@gmail.com",
                Name="Sam",
                Salary=90000,
                VacationDays = 15
            };
            var commemp = new CommissionedEmployee
            {
                Email = "John@gmail.com",
                Name="John",
                CommPerc=20,ItemsSold=50,
            };
            var db = new TablePerTypeDataContext();
            //inserting hourly, salaried and commissione emploee
            db.Employees.InsertAllOnSubmit(new Employee[] { hourlyemp, salaryemp, commemp });
            db.SubmitChanges();

            //confirm that employee got inserted.
            var db1 = new TablePerTypeDataContext();
            Console.WriteLine("All Employees");
            foreach (var emp in db1.Employees)
            {
                Console.WriteLine(emp.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Hourly Employee");
            var hremp = db.Employees.OfType<HourlyEmployee>().First();
            Console.WriteLine(hremp.Name);
        }
    }
}
