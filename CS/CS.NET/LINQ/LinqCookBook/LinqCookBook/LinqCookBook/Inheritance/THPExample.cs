using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Data.Extensions;
using NorthWind.Business.EF.Inheritance;

namespace LinqCookBook.Inheritance
{
    public static class TPHExample
    {
        static void CleanUp()
        {
            var db = new TPHAEntities();
            var cmd = db.CreateStoreCommand("delete tph.Customer;");
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
            var db = new TPHAEntities();
            var customertype = db.Types.OfType<CustomerType>().First(t => t.Value == "Advertiser");
            var leadtype = db.Types.OfType<LeadType>().First(t => t.Value == "Internet");
            var industrytype = db.Types.OfType<IndustryType>().First(t => t.Value == "Education");

            var customer = new Customer
            {
                Name="Zeeshan",
                CustomerType = customertype,
                LeadType = leadtype,
                IndustryType = industrytype
            };
            db.AddToCustomers(customer);
            db.SaveChanges();

            var db2 = new TPHAEntities();
            var cust =
                db2.Customers
                .Include("CustomerType").Include("LeadType").Include("IndustryType")
                .First(c => c.Name == "Zeeshan");

            Console.WriteLine("Name {0}", cust.Name);
            Console.WriteLine("CustomerType {0}", cust.CustomerType.Value);
            Console.WriteLine("LeadType {0}", cust.LeadType.Value);
            Console.WriteLine("IndustryType {0}", cust.IndustryType.Value);
        }

       
    }
}
