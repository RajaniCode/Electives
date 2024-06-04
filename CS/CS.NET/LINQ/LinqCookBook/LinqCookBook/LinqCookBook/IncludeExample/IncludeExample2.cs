using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.DefiningQuery;
using System.Data.Objects;
using QueryViewWithFilter;

namespace LinqCookBook.IncludeExample
{
    public class IncludeExample2
    {
        public static void Run()
        {
            Cleaanup();
            //Example1();
            


        }

        

        private static void Cleaanup()
        {
            
        }

        private static void Example1()
        {
            var db = new MultipleAssoEntities();
            string query = "select value c from Contacts as c";
            var contacts = new ObjectQuery<Contact>(query, db);
            contacts = contacts.Where("it.ContactName = @ContactName", new ObjectParameter("ContactName", "Zeeshan"));
            var contact = contacts.Include("BillingAddress").Include("ShippingAddress").First();
            Console.WriteLine("Name:{0}", contact.ContactName);
            Console.WriteLine("Billing:{0}", contact.BillingAddress.FullAddress);
            Console.WriteLine("Shipping:{0}", contact.ShippingAddress.FullAddress);

        }
    }
}
