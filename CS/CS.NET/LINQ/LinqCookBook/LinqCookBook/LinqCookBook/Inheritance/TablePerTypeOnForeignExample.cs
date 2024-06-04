using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.Extensions;
using InhQVForeign;

namespace LinqCookBook.Inheritance
{
    public class TablePerTypeOnForeignExample
    {
        static void CleanUp()
        {
            var db = new QvForeignEntities();
            var cmd = db.CreateStoreCommand("delete qv.Customers;delete qv.Employee;delete qv.Person;");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public static void Run()
        {
            CleanUp();
            var db = new QvForeignEntities();
            var customer = new Customer { AccountNo = "123", Name = "Zeeshan" };
            var employee = new Employee { CompanyName = "Chem Ltd", Name = "John" };
            db.AddToPersons(customer);
            db.AddToPersons(employee);
            db.SaveChanges();

            var db2 = new QvForeignEntities();
            var cus2 = db2.Persons.OfType<Customer>().First();
            Console.WriteLine("Name {0} PersonId {1} CustId {2}",cus2.Name,cus2.PersonId,cus2.CustomerId);

            var emp2 = db2.Persons.OfType<Employee>().First();
            Console.WriteLine("Name {0} PersonId {1} CustId {2}", emp2.Name, emp2.PersonId, emp2.EmployeeId);

        }
    }
}
