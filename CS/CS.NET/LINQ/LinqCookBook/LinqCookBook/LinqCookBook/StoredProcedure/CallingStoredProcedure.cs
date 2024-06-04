using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.StoredProcedure;
using System.Data.Objects;
using System.Data.EntityClient;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Data;
using System.Transactions;


namespace LinqCookBook.StoredProcedure
{
    public class CallingStoredProcedure
    {
        public static void RunExamples()
        {
           //CallingSimpleStoredProcedures();
          //StoredProcedureWithRelations();
           //StoredProcedureWithLoadOptions();
           //TrackingBehaviorWithStoredProcedure();
           //StoredProcedureReturningScalarValues();
          //StoredProcedureReturningAnonymousType();
            //ExecutingStoredProcedureWithNoResultSet();
            //StoredProcedureReturningBaseClass();
            //StoreProcedureWithOutPutParamters();
            //StoredProcedureWithCommandText();
        }

        private static void StoredProcedureWithCommandText()
        {
            var db = new NorthwindEntities();
            var valuedcustomer = db.CustomerWithHighestSales().First();
            Console.WriteLine(valuedcustomer.CustomerID);

            //this procedure gets total orders and total purchases made
            //for a customer and updates customersummary table.
            db.UpdateCustomerSummary("ALFKI");
        }

        private static void StoreProcedureWithOutPutParamters()
        {
            var db = new NorthwindEntities();
            int totalorders = 0;
            decimal totalpurchases = 0.0M;
            db.GetCustStats("ALFKI", ref totalorders, ref totalpurchases);
            Console.WriteLine("Order {0} Total {1}",totalorders,totalpurchases);
        }

        private static void StoredProcedureReturningBaseClass()
        {
            var db = new NorthwindEntities();
            var prods = db.GetSimpleProds();
            foreach (var prod in prods)
            {
                Console.WriteLine(prod.GetType().FullName);
            }
        }
        static void CleanUp()
        {
            var db = new NorthwindEntities();
            var orders = db.Orders.Where(o => o.ShipCity == "Dallas").ToList();
            orders.ForEach(o => db.DeleteObject(o));
            db.SaveChanges();
        }
        private static void ExecutingStoredProcedureWithNoResultSet()
        {
            CleanUp();
            var db = new NorthwindEntities();
            Order o = new Order();
            o.ShipName = "Alfred";
            o.ShipCity = "Dallas";
            o.ShippedDate = DateTime.Now.AddDays(5);
            o.CustomerReference.EntityKey = new EntityKey("NorthwindEntities.Customers", "CustomerID", "ALFKI");
            db.AddToOrders(o);
            using (TransactionScope scope = new TransactionScope())
            {
                db.SaveChanges();
                db.UpdateCustTotal("ALFKI");
                scope.Complete();
            }
            
        }

        private static void StoredProcedureReturningAnonymousType()
        {
            var db = new NorthwindEntities();
            foreach (var cussale in db.GetCusSales())
            {
                Console.WriteLine("CustID {0} Sales {1}",cussale.CustomerID,cussale.TotalSales.ToString("c"));
            }
        }
        public static void CallingSimpleStoredProcedures()
        {
            var db = new NorthwindEntities();
            var orders = db.GetOrdersForCust("ALFKI").ToList();
            foreach (var order in orders)
            {
                Console.WriteLine(order.OrderID);
            }

            foreach (var order in orders)
            {
                order.CustomerReference.Load();
                Console.WriteLine(order.Customer.CustomerID);
            }
        }

        public static void StoredProcedureWithRelations()
        {
            var db = new NorthwindEntities();
            var orders = db.GetOrdersForCust("ALFKI").ToList();
            var orderdetails = db.GetOrderDetailsForCust("ALFKI").ToList();
            // one way to attach order.
            orders.ForEach(o => o.OrderDetails.Attach(orderdetails.Where(od => od.OrderID == o.OrderID)));
            foreach (var order in orders)
            {
                Console.WriteLine(order.OrderDetails.Count());
            }

        }
        public static void StoredProcedureWithLoadOptions()
        {
            var db = new NorthwindEntities();
            var orders = db.GetOrdersForCust("ALFKI").ToList();
            var orderdetails = db.OrderDetails.
                                Where(od => od.Order.Customer.CustomerID == "ALFKI")
                                .ToList();
            foreach (var order in orders)
            {
                Console.WriteLine(order.OrderDetails.Count());
            }
        }
        public static void TrackingBehaviorWithStoredProcedure()
        {
            var db = new NorthwindEntities();
            
            //cant call the stored procedure with no tracking option.
            var orders = db.GetOrdersForCust("ALFKI").ToList();
            

            //no database call is made because objects are being tracked.
            var fetchedorder = db.GetObjectByKey(orders.First().EntityKey);

            //detach the objects
            orders.ForEach(o => db.Detach(o));
            //no database call is made
            db.GetObjectByKey(orders.First().EntityKey);

        }
        public static void StoredProcedureReturningScalarValues()
        {
            var db = new NorthwindEntities();
            decimal totalsales = db.TotalSalesForCust("ALFKI");
        }

       
        
    }
}
