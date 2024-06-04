using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.Miscellaneos;
using Microsoft.Data.Extensions;
using System.Threading;

namespace LinqCookBook.Miscellaneos
{
    public class UsingXmlWithEF
    {
        static void CleanUp()
        {
            var db = new GuidsAsIdentityEntities();
            var cmd = db.CreateStoreCommand("delete sr.Customer;");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            var db2 = new StComputedEntities();
            var cmd2 = db2.CreateStoreCommand("delete sr.supplier;");
            cmd2.Connection.Open();
            cmd2.ExecuteNonQuery();
            cmd2.Connection.Close();

        }

        public static void Run()
        {
            CleanUp();
            //Example1();
            //Example2();
            Example3();
        }

        private static void Example3()
        {
            var db = new StComputedEntities();
            var supplier = new Supplier
            {
                SupplierName = "Exotic Liquids"
            };
            db.AddToSupplier(supplier);
            db.SaveChanges();
            Console.WriteLine();
            Console.WriteLine("supplier insert details");
            Console.WriteLine("Create Date:{0}", supplier.CreateDate.Value.ToString());
            Console.WriteLine("Modified Date:{0}", supplier.modifiedDate.Value.ToString("hh:mm:ss"));

            Thread.Sleep(TimeSpan.FromSeconds(3));
            supplier.SupplierName = "Exotic Liquids Ltd.";
            db.SaveChanges();
            Console.WriteLine("Update Details");
            Console.WriteLine("Modified Date:{0}", supplier.modifiedDate.Value.ToString("hh:mm:ss"));
        }

        private static void Example2()
        {
            var db = new GuidsAsIdentityEntities();
            var customer = new Customer
            {

                Email = "abc@gmail.com",
                Name = "Zeeshan"
            };

            db.AddToCustomers(customer);
            db.SaveChanges();
            Console.WriteLine("CustomerID:{0}",customer.CustomerId.ToString("D"));
            //update teh contact
            customer.Name = "Zeeshan Hirani";
            db.SaveChanges();

            db.DeleteObject(customer);
            db.SaveChanges();
        }

        private static void Example1()
        {
            var db = new XmlEntities();
            var candidate = db.Candidates.First();
            Console.WriteLine("Resume " + candidate.CandidateResume.ToString());
            candidate.CandidateResume.SetElementValue("Content", "Resume update " + DateTime.Now);

            db.SaveChanges();

            var db2 = new XmlEntities();
            var updatedcand = db2.Candidates.First();
            Console.WriteLine("Updated Resume " );
            Console.WriteLine(updatedcand.CandidateResume.ToString());

        }
    }
}
