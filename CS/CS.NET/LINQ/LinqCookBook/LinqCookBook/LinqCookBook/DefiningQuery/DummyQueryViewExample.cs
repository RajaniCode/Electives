using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.DefiningQuery;

namespace LinqCookBook.DefiningQuery
{
    public class DummyQueryViewExample
    {
        public static void Run()
        {
            var db = new DDQEntities();
            foreach (var cus in db.GetCusSales())
            {
                Console.WriteLine("Customer {0} Sale {1}",cus.CustomerID,cus.TotalSales);
            }
        }
    }
}
