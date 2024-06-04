using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace NorthWind.Business.EF
{
    public partial class Customer
    {
        public Customer()
        {
            this.Orders.AssociationChanged += new System.ComponentModel.CollectionChangeEventHandler(Orders_AssociationChanged);
        }

        public static void TestForAssociationChangedEvents()
        {
            var db = new NorthwindEFEntities();
            Console.WriteLine("Following are cases when association changed event fires");

            Console.WriteLine("Include in the query raises an action of add");
            var THECR = db.Customers.Include("Orders").First(c => c.CustomerID == "THECR");

            var TRAIH = db.Customers.First(c => c.CustomerID == "TRAIH");
            var LAZYK = db.Customers.First(c => c.CustomerID == "LAZYK");

            Console.WriteLine(@"Calling Load causes an action of refresh only 1 time regardless of # of orders");
            TRAIH.Orders.Load();

            Console.WriteLine(@"Orders returned from query belonging to a customer being tracked causes Add action");
            db.Orders.Where(o => o.ShipCity == "Walla Walla").ToList();//customer LAZYK

            Console.WriteLine(@"Rexecuting the same query does not trigger any action.");
            db.Orders.Where(o => o.ShipCity == "Walla Walla").ToList();


            Console.WriteLine("Calling Removes fires an action of remove");
            var THECRorder = THECR.Orders.First();
            THECR.Orders.Remove(THECRorder);

            Console.WriteLine("Clearing all orders causes an action of Refresh.");
            THECR.Orders.Clear();

            Console.WriteLine("Calling Add on Orders Collection causes an action of Add.");
            THECR.Orders.Add(new Order { ShipCity = "London", ShipCountry = "UK", OrderDate = DateTime.Today });

            var TRAIHorder = TRAIH.Orders.First(o => o.OrderID == 10574);
            Console.WriteLine(@"adding existing order causes remove and than an add action.");
            THECR.Orders.Add(TRAIHorder);

            var LAZYKorder = db.Orders.First(o => o.OrderID == 10482);
            Console.WriteLine("Detaching an order causes the order to be removed from customer's order collection");
            db.Detach(LAZYKorder);
            Console.WriteLine("Calling Attach causes an action of Add if the customer is already being tracked");
            db.Attach(LAZYKorder);

            var HANARorder = db.Orders.First(o => o.OrderID == 10253);
            db.Detach(HANARorder);
            //calling attach does not cause an action of add since no customer for the order was tracked.
            db.Attach(HANARorder);
            Console.WriteLine("Attaching orders to orders collection causes an action of refresh");
            THECR.Orders.Attach(HANARorder);

            //Assigning HANARorder from customer THECR to LAZYK
            Console.WriteLine("Assigning customer instance on existing order  causes action of remove and add");
            
            Console.WriteLine("Calling DeleteObject causes an action of remove if customer is being tracked.");
            db.DeleteObject(HANARorder);


            Console.WriteLine("Calling delete on objectstate entry causes an action of remove.");
            db.ObjectStateManager.GetObjectStateEntry(LAZYKorder).Delete();  
            
        }

        void Orders_AssociationChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e)
        {
            Console.WriteLine(e.Action.ToString());
        }

        
        public static IQueryable<Customer> GetCustomersByContactTitle(string contacttitle, int start, int max)
        {
            var db = new NorthwindEFEntities();
            
            var custs = db.Customers.AsQueryable();
            if (contacttitle != null)
            {
                custs = custs.Where(c => c.ContactTitle == contacttitle);
            }
            //ordering is required by entity framework if you are going to use
            //skip operator in the query. Linq to sql does not impose any constraints
            //for paging through the results.
            
            custs = custs.OrderBy(c => c.CompanyName)
                        .Skip(start).Take(max);
            var stuff = custs.ToString();
            return custs;
        }

        static void db_SavingChanges(object sender, EventArgs e)
        {
            
        }

        public static int GetCustomersByContactTitleCount(string contacttitle)
        {
            var db = new NorthwindEFEntities();
            var custs = db.Customers.AsQueryable();
            if (contacttitle != null)
            {
                custs = custs.Where(c => c.ContactTitle == contacttitle);
            }
            return custs.Count();
        }
    }
}