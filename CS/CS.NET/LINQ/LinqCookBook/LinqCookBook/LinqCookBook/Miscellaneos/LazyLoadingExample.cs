using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Objects;
using NorthWind.Business.EF.NorthWindFull;

namespace LinqCookBook.Miscellaneos
{
    public class LazyLoadingExample
    {
        public static void Run()
        {
            var db = new NorthwindFullEntities();
            db.Orders.MergeOption = MergeOption.NoTracking;
            var order = db.Orders.First();
            Console.WriteLine("CustomerID is {0}", order.CustomerReference.EntityKey == null ? "null": "not null");
            order.CustomerReference.Load();
            Console.WriteLine("Order's Customer is {0}",order.Customer.CustomerID);
        }
    }
}
