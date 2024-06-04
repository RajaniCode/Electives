using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmInheritance.TPTTPH;
using Microsoft.Data.Extensions;

namespace LinqCookBook.Inheritance
{
    public static class EmployeeInheritanceExample
    {
        static void CleanUp()
        {
            var db = new EmployeeTPHTPT();
            var cmd = db.CreateStoreCommand("delete TBH.SalariedEmployee;delete TBH.ClubMembers;delete TBH.Persons;");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }

        public static void Run()
        {
            CleanUp();
            TablePerTypeWithTPH();
        }

        private static void TablePerTypeWithTPH()
        {
            var db = new EmployeeTPHTPT();
            var hourlyemp = new HourlyEmployee { EmployeeNumber = "123", Name = "Zee", Hours = 40, Rate = 60 };
            var salariedemp = new SalariedEmployee { EmployeeNumber = "111", Name = "Alex", Salary = 90000 };
            var regularcustomer = new Customer { Name = "John", LoginAccount = "john" };
            var clubmember = new ClubMember { Name = "Craig", LoginAccount = "craig", ClubDiscount = 100 };
            db.AddToPersons(hourlyemp);
            db.AddToPersons(salariedemp);
            db.AddToPersons(regularcustomer);
            db.AddToPersons(clubmember);
            db.SaveChanges();
            
            var db2 = new EmployeeTPHTPT();
            Console.WriteLine("Total Employees " + db2.Persons.OfType<Employee>().Count());
            Console.WriteLine("Total Customers " + db2.Persons.OfType<Customer>().Count());
            Console.WriteLine("Total ClubMembers " + db2.Persons.OfType<ClubMember>().Count());
        }
    }
}
