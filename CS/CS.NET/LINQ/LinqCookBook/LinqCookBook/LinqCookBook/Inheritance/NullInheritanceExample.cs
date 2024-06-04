using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NullInheritance;
using Microsoft.Data.Extensions;

namespace LinqCookBook.Inheritance
{
    public class NullInheritanceExample
    {
        static void CleanUp()
        {
            var db = new IsNullInhEntities();
            var cmd = db.CreateStoreCommand("delete tbhc.contacts;");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }

        public static void Run()
        {
            CleanUp();
            var contact = new Contact { Name = "Zeeshan", Address = "123" };
            var customer = new Customer { Name = "Alex", Address = "123", IsClubMember = true };
            var employee = new Employee { Name = "John", Address = "123", CompanyName = "True LTD" };
            var db = new IsNullInhEntities();
            db.AddToContacts(contact);
            db.AddToContacts(customer);
            db.AddToContacts(employee);
            db.SaveChanges();
            var db2 = new IsNullInhEntities();
            Console.WriteLine("Incorrect contacts only " + db2.Contacts.OfType<Contact>().Count());
            var esql = @"select value c from OfType(Contacts,only NullInheritance.Contact) as c";
            Console.WriteLine("Correct Contacts only " + db2.CreateQuery<Contact>(esql).Count());
        }
    }
}
