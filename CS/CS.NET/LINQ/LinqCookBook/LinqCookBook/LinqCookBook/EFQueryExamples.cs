using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF;
using System.Data.Objects;
using NorthWind.Business.EF.LazyLoading;
using NorthWind.Business.EF.NorthWindFull;
using System.Data;

namespace LinqCookBook
{
    public partial class EFQueryExamples
    {

        public static void InClause()
        {
            //1st way to do it.
            var cities = new [] {"London","Berlin"};
            var cityparams = string.Join(",", 
                            cities.Select(c => "'" + c + "'")
                            .ToArray());

            var db = new NorthwindEFEntities();
            
            string sql = @"
                Select value c from Customers as c
                where c.City in {" + cityparams + "}";

            var custs =
            db.CreateQuery<Customer>(sql);

            Console.WriteLine("Customers for London " + 
                custs.Count(c => c.City == "London "));

            Console.WriteLine("Customers for Berlin " +
                custs.Count(c => c.City == "Berlin"));
         
            //2nd way to do it.
            var custs2 =
            db.Customers.Where("it.City in {@cities}",new ObjectParameter("cities",cityparams));

            Console.WriteLine("Customers for London " +
                custs2.Count(c => c.City == "London "));

            Console.WriteLine("Customers for Berlin " +
                custs2.Count(c => c.City == "Berlin"));

            var all = from ct in cities
                        join c in db.Customers on ct equals c.City
                        select c;
            Console.WriteLine("Customers from London and Berlin " + all.Count());
        }

        public static void ExampleOfLazyLoading()
        {
            var db = new LazyLoadingEntities();
            var ALFKI = db.Customers.First(c => c.CustomerID == "ALFKI");
            var ANATR = db.Customers.First(c => c.CustomerID == "ANATR");

            //simple lazy loading of all orders for a ALFKItomer.
            ALFKI.Orders.Load();
            Console.WriteLine("Initial load " + ALFKI.Orders.Count());
            //calling load again hits the database as well
            ALFKI.Orders.Load();
            Console.WriteLine("Loading again same results " + ALFKI.Orders.Count());
            //removes all items from the collection
            ALFKI.Orders.Clear();
            Console.WriteLine("Orders cleared");
            
            //reloads the entire collection but count is still 0 because default is preserve changes
            ALFKI.Orders.Load();
            //confirms the count is 0
            Console.WriteLine("after reloading " + ALFKI.Orders.Count());
            //we need to reload our orders and discard our client changes.
            ALFKI.Orders.Load(MergeOption.OverwriteChanges);
            
            //confirm total orders is greater than 0
            Console.WriteLine("reload with overwrite " + ALFKI.Orders.Count());
            //change one of the properties on the orders collection.
            var ALFKIorder = ALFKI.Orders.Single(o => o.OrderID == 10643);
            ALFKIorder.ShipCity = "London";
            Console.WriteLine("existing order's city changed to London");
            ALFKI.Orders.Load(MergeOption.AppendOnly);
            //ship city still remains as London
            Console.WriteLine("After load with appendly only existing order city " + ALFKIorder.ShipCity);

            ALFKI.Orders.Load(MergeOption.OverwriteChanges);
            Console.WriteLine("After load with overwrite existing order city " + ALFKIorder.ShipCity);
            
            //assign the alfki order to anatr customer
            ALFKIorder.Customer = ANATR;
            //alfki orders reduces by 1
            Console.WriteLine("ALFKI orders after assigning order to ANATR " + ALFKI.Orders.Count());
            ALFKI.Orders.Load(MergeOption.OverwriteChanges);
            //alfki ordres is fixed and increase by 1
            Console.WriteLine("ALFKI orders after with overwrite " + ALFKI.Orders.Count());
            //antara no longer owns 10643 order
            Console.WriteLine("ANATR orders after with overwrite " + ANATR.Orders.Count());

            
           //loading only pat of the orders. 
           ANATR.Orders.Attach(ANATR.Orders.CreateSourceQuery().Where(o => o.Freight <= 20));
            Console.WriteLine("Antarr orders partly loaded " + ANATR.Orders.Count());
            //calling load will load the entire graph.
            ANATR.Orders.Load(MergeOption.OverwriteChanges);
            Console.WriteLine("ANATR orders after  load with overwrite " + ANATR.Orders.Count());

            //what doesn't work

            var ANTON = db.Customers.First(c => c.CustomerID == "ANTON");
           //code crashes because you cant load related entity with no tracking
            //ANTON.Orders.Load(MergeOption.NoTracking);

            
            var qry = db.Customers;
            qry.MergeOption = MergeOption.NoTracking;
            var AROUT = qry.First(c => c.CustomerID == "AROUT");
           
            //default uses no tracking option to load.
            AROUT.Orders.Load(); 
            
            //doesn't work  because customer was loaded with no tracking
            //and orders are loading using overwrite chnages.
            //AROUT.Orders.Load(MergeOption.OverwriteChanges);

            //works because customer was retrieved using no tracking as well.
            //AROUT.Orders.Load(MergeOption.NoTracking);


            var testcustomer = new Customer { CustomerID = "ALFK5", City = "Dallas", CompanyName = "XYZ" };
            //cant call load on customer that is in added state.
            //testcustomer.Orders.Load();

            
            db = new LazyLoadingEntities();
            var BERGS = db.Customers.First(c => c.CustomerID == "BERGS");
            db.DeleteObject(BERGS);
            //discuss the error because cant call load when sourc entity is in deleted status.
            //BERGS.Orders.Load();

            var COMMI = db.Customers.First(c => c.CustomerID == "COMMI");
            db.Detach(COMMI);
            //cant deleted cuz its in detached state.
            //COMMI.Orders.Load();


        }

        public static void ManyToManyCollection()
        {
            var db = new NorthwindEFEntities();
            var emp2 = db.Employees.First(e => e.EmployeeID == 2);
            var emp5 = db.Employees.First(e => e.EmployeeID == 5);
            Console.WriteLine(emp2.Territories.Count());
            emp2.Territories.Load();
            Console.WriteLine(emp2.Territories.Count());
            var terr = emp2.Territories.First();
            terr.Employees.Add(emp5);
            Console.WriteLine(emp5.Territories.Count());
            emp2.Territories.Load(MergeOption.OverwriteChanges);
            Console.WriteLine(emp5.Territories.Count());
            Console.WriteLine(emp2.Territories.Count());
        }

       public static void UsingLoad()
       {
           var db = new LazyLoadingEntities();
           var alfki = db.Customers.First(c => c.CustomerID == "ALFKI");
           if (!alfki.Orders.IsLoaded)
           {
               alfki.Orders.Load();
           }

           var orders = db.Orders.Where(o => o.ShipCity == "London");
           int databasecalls = 0;
           foreach (var order in orders)
           {
               order.CustomerReference.Load();
               databasecalls++;
           }
           Console.WriteLine("Total database calls " + databasecalls);
       }
        public static void OverWriteChangesDoesNotWork()
        {
            var db = new LazyLoadingEntities();

            //ALFKI has 6 orders.
            var ALFKI = db.Customers.Include("Orders").First(c => c.CustomerID == "ALFKI");
            //ANATR has 4 orders.
            var ANATR = db.Customers.Include("Orders").First(c => c.CustomerID == "ANATR");

            //get one alfki order
            var ALFKIorder = ALFKI.Orders.Single(o => o.OrderID == 10643);

            //assign it to ANATR customre
            ALFKIorder.Customer = ANATR;
            Console.WriteLine("ALFKI has {0} orders", ALFKI.Orders.Count());// 5 orders
            Console.WriteLine("ANATR has {0} orders", ANATR.Orders.Count()); //5 orders

            ALFKI.Orders.Load(MergeOption.OverwriteChanges);

            //relation gets overwritten to what's in the database
            Console.WriteLine("ALFKI has {0} orders", ALFKI.Orders.Count());// 6 orders
            Console.WriteLine("ANATR has {0} orders", ANATR.Orders.Count()); //4 orders

            //let's do this again and we should now be back to 5 for alfki and 5 for ANATR
            //
            ALFKIorder.Customer = ANATR;

            //let's overwrite changes using ANATR
            ANATR.Orders.Load(MergeOption.OverwriteChanges);

            //nothing gets changed at all. i should have only 4 for
            //ANATR as defined by the databaes.
            Console.WriteLine("ALFKI has {0} orders", ALFKI.Orders.Count());// 5 orders
            Console.WriteLine("ANATR has {0} orders", ANATR.Orders.Count()); //5 orders


        }
        private static void UsingFirstAndSingle()
        {
            var db = new NorthwindEFEntities();
             //using linq syntax
            var ALFKI = db.Customers.First(c => c.CustomerID == "ALFKI");
            Console.WriteLine("ALFKI returned using first operator " + ALFKI.CustomerID);

            //create an entity key
            EntityKey key = new EntityKey("NorthwindEFEntities.Customers", "CustomerID", "ALFKI");
            //if object is found in the cache use that otherwise get it from database.
            var ALFKI2 = db.GetObjectByKey(key) as Customer;
            Console.WriteLine("Object retrieved from the cache " + ALFKI2.CustomerID);

             EntityKey notfoundkey = new EntityKey("NorthwindEFEntities.Customers", "CustomerID", "ABCDE");
             Object notfound = null;
             db.TryGetObjectByKey(notfoundkey,out notfound);
             Console.WriteLine("Customer found {0}" ,notfound != null);
        }
        private static void CallingFirstTwice()
        {
            var db = new NorthwindEFEntities();
            var ALFKI = db.Customers.First(c => c.CustomerID == "ALFKI");
            //second database call. does not retrieve from cache.
            var ALFKI2 = db.Customers.First(c => c.CustomerID == "ALFKI");
            //object references are same.
            Console.WriteLine("Is reference same {0}", ALFKI == ALFKI2);
        }
        private static void UsingFirstORDefault()
        {
            var db = new NorthwindEFEntities();
            var cust = db.Customers.FirstOrDefault(c => c.CustomerID == "ABCDE");
            //no customer exists with customerid ABCDE
            Console.WriteLine("Customer found {0}", cust != null);
        }
        public static void DifferentUsagesofGetObjectByKey()
        {
            var db = new NorthwindEFEntities();
            var ALFKI = db.Customers.First(c => c.CustomerID == "ALFKI");
            ////detaching the object would remove the object from tracking
            ////so query will hit the database again.
            db.Detach(ALFKI);
            var ALFKI3 = db.GetObjectByKey(ALFKI.EntityKey) as Customer;


            ////if you attach it back again then query would not hit the database.
            db.Attach(ALFKI3);
            ////does not hit the database
            db.GetObjectByKey(ALFKI3.EntityKey);

            db.DeleteObject(ALFKI3);
            ////can retrieve objects in deleted state
            db.GetObjectByKey(ALFKI3.EntityKey);

            Customer cus = new Customer { CustomerID = "12345", City = "London" };
            db.AddToCustomers(cus);
            //can be called on objects in added state
            db.GetObjectByKey(cus.EntityKey);

            //raises exception since object is created but not yet inserted
            //db.Customers.First(c => c.CustomerID == "12345");
        }

        private static void GetObjectByKeyWithNoTracking()
        {
            var db = new NorthwindEFEntities();
            var custs = db.Customers;
            custs.MergeOption = MergeOption.NoTracking;
            //object is tracked despite no tracking
            var cus1 = custs.First(c => c.CustomerID == "ALFKI");
            //query does not hit the database because object is cached.
            db.GetObjectByKey(cus1.EntityKey);

            var results = db.Customers;
            results.MergeOption = MergeOption.NoTracking;
            //objects not tracked.
            results.Where(c => c.City == "London").ToList();
            //call issued to the database.
            var fromcache = db.GetObjectByKey(new EntityKey("NorthwindEFEntities.Customers", "CustomerID", "BSBEV"));
        }
        /// <summary>
        /// show different examples of get object by key.
        /// </summary>
        public static void ExampleOfGetObjectByKey()
        {
            var db = new NorthwindEFEntities();

            UsingFirstAndSingle();
            CallingFirstTwice();
            UsingFirstORDefault();
            DifferentUsagesofGetObjectByKey();
            GetObjectByKeyWithNoTracking();
        }
    }
}
