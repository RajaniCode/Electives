using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqCookBook.EFUsingPOCO
{
    public class CustomerORders
    {
        public static void CustomerWithOrders()
        {
            var db = new NorthwindEntities();
            var custs = db.Customers.Where(c => c.ContactTitle == "Sales Representative");
            foreach (var cus in custs)
            {
                cus.Orders.Load();
                Console.WriteLine("cust {0} OrderCount:{1}",cus.CustomerID,cus.Orders.Count());
            }
        }

        public static void OrdersWithCustomer()
        {
            var db = new NorthwindEntities();
            var orders = db.Orders.Where(o => o.ShipCity == "Portland");
            foreach (var order in orders)
            {
                Console.WriteLine("Order ID:{1} CustID:{1}",order.OrderID,order.Customer.CustomerID);
            }
        }

        public static void CustomersWithSalesRepresentative()
        {
            var db = new NorthwindEntities();
            var custs = db.Customers.Where(c => c.ContactTitle == "Sales Representative");
            foreach (var cus in custs)
            {
                Console.WriteLine("cust {0}", cus.CustomerID);
            }
        }
    }
}
