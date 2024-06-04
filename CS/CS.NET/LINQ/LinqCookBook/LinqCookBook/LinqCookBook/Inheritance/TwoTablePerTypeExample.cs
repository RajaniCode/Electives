using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.Extensions;
using TwoTPT;

namespace LinqCookBook.Inheritance
{
    class TwoTablePerTypeExample
    {
        static void CleanUp()
        {
            var db = new TwoTPTEntities();
            var cmd = db.CreateStoreCommand("delete tpt.Location;delete tpt.Company;delete tpt.Contact;delete tpt.GunSmith;");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }

        public static void Run()
        {
            CleanUp();
            Example1();
        }

        private static void Example1()
        {
            var db = new TwoTPTEntities();
            var company = new Company { Address = "123 Happy St", CompanyName = "Widgets", Phone = "918-998-9956" };
            var gunsmith = new GunSmith
            {
                ContactName = "Zeeshan",
                Email = "abc@gmail.com",
                IsCertified = true,
                Company = company
            };
            db.AddToContact(gunsmith);
            db.SaveChanges();

            var db2 = new TwoTPTEntities();
            var gsmith = db2.Contact.OfType<GunSmith>().Include("Company").First();
            Console.WriteLine("Contact {0} Company {1}",gsmith.ContactName, gsmith.Company.CompanyName);
        }
    }
}
