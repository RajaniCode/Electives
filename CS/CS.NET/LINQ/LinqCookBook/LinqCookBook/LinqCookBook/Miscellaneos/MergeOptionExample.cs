using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF;
using System.Data.Objects;
using System.Data;
using Microsoft.Data.Extensions;

namespace LinqCookBook.Miscellaneos
{
    public class MergeOptionExample
    {
        public static void Run()
        {
            CleanUp();
            //OverWriteChanges();
            //UsingNoTrackingQuery();
            //ReusingSameObjectQuery();
            //RelatedEntities();
           // IncludeNoTracking();
            //UpdateNoTracking();
            //ObjectComparision();
           // AppendOnly();
            PreserveChanges();
        }

        private static void AppendOnly()
        {
            var db = new NorthwindEFEntities();
            var customer = db.Customers.First(c => c.CustomerID == "WOLZA");
            Console.WriteLine("City: " + customer.City);
            //change Wolza customer's city to paris
            ChangeCitytoParis();
            Console.WriteLine("After change ");
            db.Customers.MergeOption = MergeOption.AppendOnly;
            db.Customers.First(c => c.CustomerID == "WOLZA");

            Console.WriteLine("City: " + customer.City);
        }


        private static void CleanUp()
        {
            var db = new NorthwindEFEntities();
            var cmd = db.CreateStoreCommand("update customers set city ='Warszawa' where customerid = 'WOLZA';");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        private static void PreserveChanges()
        {
            var db = new NorthwindEFEntities();
            var customer = db.Customers.First(c => c.CustomerID == "WOLZA");
            //change city to london.
            customer.City = "London";
            //original city is Warszawa
            string orignalcity = (string)db.ObjectStateManager.GetObjectStateEntry(customer).OriginalValues["City"];
            Console.WriteLine("Original City " + orignalcity);
            Console.WriteLine("Changed City " + customer.City);

            //change city in the database without notifying objectcontext.
            ChangeCitytoParis();
            //refresh customer with preserve changes.
            db.Customers.MergeOption = MergeOption.PreserveChanges;
            db.Customers.First(c => c.CustomerID == "WOLZA");
            string _orignalcity = (string)db.ObjectStateManager.GetObjectStateEntry(customer).OriginalValues["City"];
            Console.WriteLine("After refreshing customer using Preserve changes");
            Console.WriteLine("Original City " + _orignalcity);
            Console.WriteLine("Changed City " + customer.City);
            
        }

        private static void ChangeCitytoParis()
        {
            var db = new NorthwindEFEntities();
            var cmd = db.CreateStoreCommand("update customers set city ='Paris' where customerid = 'WOLZA';");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        

       

        private static void ObjectComparision()
        {
            var db = new NorthwindEFEntities();
            var cust1 = db.Customers.First();
            var cust2 = db.Customers.First();
            Console.WriteLine("Tracking query. Object same {0}", cust1 == cust2);

            //non tracking
            db.Customers.MergeOption = MergeOption.NoTracking;
            var cust3 = db.Customers.First();
            var cust4 = db.Customers.First();
            Console.WriteLine("Non Tracking query. Object same {0}", cust3 == cust4);
        }

        private static void UpdateNoTracking()
        {
            var db = new NorthwindEFEntities();
            db.Customers.MergeOption = MergeOption.NoTracking;
            var customer = db.Customers.First();
            Console.WriteLine(customer.CustomerID);
            //attach teh customer
            db.Attach(customer);
            customer.Phone = "817-355-9899";
            db.SaveChanges();
        }

        private static void IncludeNoTracking()
        {
            var db = new NorthwindEFEntities();
            db.Customers.MergeOption = MergeOption.NoTracking;
            var cust = db.Customers.Include("Orders").First();
            Console.WriteLine(cust.Orders.Count());
            
                

        }

        private static void RelatedEntities()
        {
            var db = new NorthwindEFEntities();
            var cust = db.Customers.First();
            //will raise runtime error
            cust.Orders.Load(MergeOption.NoTracking);


            

        }

        private static void ReusingSameObjectQuery()
        {
            var db = new NorthwindEFEntities();
            db.Customers.MergeOption = MergeOption.NoTracking;
            var custs = db.Customers.Where(c => c.City == "London");

            var salesrep = db.Customers.Where(c => c.ContactTitle == "Sales Representative");
            var customers = db.CreateQuery<Customer>("Customers");
            customers.MergeOption = MergeOption.NoTracking;
            customers.Where(c => c.City == "London");
        }

        private static void UsingNoTrackingQuery()
        {
            var db = new NorthwindEFEntities();
            //object query
            db.Customers.MergeOption = MergeOption.NoTracking;
            var custquery = db.Customers.Where(c => c.City == "London").Take(2);
            var custs1 = ((ObjectQuery<Customer>)custquery).Execute(MergeOption.NoTracking);
            
            //using esql
            string esql = "select value c from customers as c where c.CustomerID = 'ALFKI'";
            db.CreateQuery<Customer>(esql).Execute(MergeOption.NoTracking).First();

            //entity reference
            //order.CustomerReference.Load(MergeOption.NoTracking);

            //entity collection
            //category.Products.Load(MergeOption.NoTracking);

        }

        private static void OverWriteChanges()
        {
            var db = new NorthwindEFEntities();
            string esql = "select value c from customers as c where c.CustomerID = 'ALFKI'";
            var cust = db.CreateQuery<Customer>(esql).First();
            
            //Berlin
            Console.WriteLine(cust.City);

            //change it to london
            cust.City = "London";
            db.CreateQuery<Customer>(esql).Execute(MergeOption.OverwriteChanges).First();
            
            Console.WriteLine(cust.City);
            
            //change it london against and this time use preserve changes which would ensure city does not get
            //overwritten from database.
            cust.City = "London";
            db.CreateQuery<Customer>(esql).Execute(MergeOption.PreserveChanges).First();
            Console.WriteLine(cust.City);
            var cust3 = db.CreateQuery<Customer>(esql).Execute(MergeOption.NoTracking).First();
            Console.WriteLine(cust3 == cust);
            
        }
    }
}
