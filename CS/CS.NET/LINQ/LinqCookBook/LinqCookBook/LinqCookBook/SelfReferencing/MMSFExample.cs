using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.SelfReferencing;
using Microsoft.Data.Extensions;

namespace LinqCookBook.SelfReferencing
{
    public class MMSFExample
    {
        public static void Run()
        {
            CleanUp();
            Example1();
        }

        static void CleanUp()
        {
            var db = new MMSFEntities();
            var cmd = db.CreateStoreCommand("delete sr.Friends;delete sr.[User]");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }


        private static void Example1()
        {
            var db = new MMSFEntities();
            var user = new User
            {
                Name = "Zeeshan",
                Contacts = 
                {
                    new User
                    {
                        Name = "Chuck",
                        Contacts = {new User{Name="Kirk"}}
                    },
                    new User
                    {
                        Name="Larry"
                    }
                }
            };
            db.AddToUsers(user);
            db.SaveChanges();

            var db2 = new MMSFEntities();
            var zeeshan = db2.Users.Include("Contacts").First(u => u.Name == "Zeeshan");
            Console.WriteLine("Zeeshan's Friends");
            foreach (var User in zeeshan.Contacts)
            {
                Console.WriteLine(User.Name);
            }

            var chuck = db2.Users.Include("Contacts").Include("OtherContacts").First(u => u.Name == "Chuck");
            //chuck's friend is Kirk
            Console.WriteLine("\r\nChuck's Friends");
            foreach (var User in chuck.Contacts)
            {
                Console.WriteLine(User.Name);
            }
            //zeeshan has Chuck as his contact which makes zeeshan as Chuck's otherContact.
            foreach (var User in chuck.OtherContacts)
            {
                Console.WriteLine(User.Name);
            }
        }
    }
}
