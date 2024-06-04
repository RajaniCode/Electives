using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.Extensions;
using NorthWind.Business.EF.Inheritance;
namespace LinqCookBook.Inheritance
{
    public class ExampleTPHQV
    {
        static void CleanUp()
        {
            var db = new TPHQVEntities();
            var cmd = db.CreateStoreCommand("delete tbh.ContactInfo;");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }

        public static void Run()
        {
            CleanUp();
            Example();
        }

        private static void Example()
        {
            var db = new TPHQVEntities();
            var homephone = new HomePhone { PhoneNumber = "817-354-9989" };
            var cellphone = new CellPhone { PhoneNumber = "817-354-9988" };
            var emailaddr = new EmailAddress { Email = "abc@gmail.com" };

            db.AddToContactInfos(homephone);
            db.AddToContactInfos(cellphone);
            db.AddToContactInfos(emailaddr);
            db.SaveChanges();

            var db2 = new TPHQVEntities();
            var hphone = db2.ContactInfos.OfType<HomePhone>().First();
            var cphone = db2.ContactInfos.OfType<CellPhone>().First();
            var eaddr = db2.ContactInfos.OfType<EmailAddress>().First();

            Console.WriteLine("Home Phone {0}", hphone.PhoneNumber);
            Console.WriteLine("Cell Phone {0}", cphone.PhoneNumber);
            Console.WriteLine("Email Addr {0}", eaddr.Email);
        }
    }
}
