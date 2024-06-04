using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultipleConditions;
using Microsoft.Data.Extensions;

namespace LinqCookBook.Inheritance
{
    public class MultipleConditionExample
    {
        public static void Run()
        {
            CleanUp();
            var db = new MultipleConditionEntities();
            var customer = new Customer { Name = "zeeshan", Phone = "717-888-9191" };
            var clubmember = new ClubMember { Name = "Alex", Phone = "712-111-4545" };
            db.AddToCustomer(customer);
            db.AddToCustomer(clubmember);
            db.SaveChanges();

            var db2 = new MultipleConditionEntities();
            foreach (var cust in db2.Customer)
            {
                Console.WriteLine("Type:{0} Name:{1}",cust.GetType().Name,cust.Name);
            }
        }

        static void CleanUp()
        {
            var db = new MultipleConditionEntities();
            var cmd = db.CreateStoreCommand("delete inh.Customer;");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }
    }
}
