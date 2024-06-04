using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.EntitySplitting;
using Microsoft.Data.Extensions;

namespace LinqCookBook.EntitySplitting
{
    public class EntitySplittingExample
    {
        static void CleanUp()
        {
            var db = new ESEntities();
            var cmd = db.CreateStoreCommand("delete TBH.SalariedEmployee;delete TBH.ClubMembers;delete TBH.Persons;");
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
            var db = new ESEntities();
            var customer = new Customer
            {
                Name="Zeeshan",
                AccountNo="123",
                AccountBalance = 500,
                ClubName="SoccerClub",
                Dues=10
            };
            db.AddToCustomers(customer);
            db.SaveChanges();

            var db2 = new ESEntities();
           var cust = db2.Customers.First(c => c.Name == "Zeeshan");
           Console.WriteLine("Name {0} Club {1} AccountNo {2}",cust.Name,cust.ClubName,cust.AccountNo);
        }
    }
}
