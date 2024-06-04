using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.DefiningQuery;
using Microsoft.Data.Extensions;

namespace LinqCookBook.DefiningQuery
{
    public class ReadOnlyExample
    {
       

        public static void Run()
        {
            Example1();
        }

        private static void Example1()
        {
            var db = new DQReadEntities();
            foreach (var customer in db.Customers)
            {
                Console.WriteLine("Name {0} TotalOrders {1} Purchases {2}", customer.Name, customer.TotalOrders, customer.TotalPurchases);
            }
        } 
    }
}
