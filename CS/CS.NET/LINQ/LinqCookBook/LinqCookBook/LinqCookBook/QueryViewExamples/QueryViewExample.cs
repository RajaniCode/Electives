using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.QueryView;
using Microsoft.Data.Extensions;

namespace LinqCookBook.QueryViewExamples
{
    public class QueryViewExample
    {
        static void ExlcudingColumns()
        {
            var db = new QueryViewEntities();
            var custs = db.Customers.Where(c => c.CustomerID == "ALFKI" || c.CustomerID == "HANAR");
            Console.WriteLine("ID\t CompanyName\t\t UserName \t HasAccount");
            foreach (var cus in custs)
            {
                Console.WriteLine("{0}\t {1}\t {2}\t {3}",
                    cus.CustomerID, cus.CompanyName, cus.UserName == null ? "No UserName" : cus.UserName, cus.HasAccount);
                Console.WriteLine();
            }
        }
        public static void Run()
        {
            //ExlcudingColumns();
            FilteringColumns();
            
        }

        

        public static void FilteringColumns()
        {
            var db = new QueryViewWithFilter.QueryViewWithFilter();
            var cmd = db.CreateStoreCommand("SELECT COUNT(*) FROM ORDERS WHERE CUSTOMERID = 'SAVEA'");
            cmd.Connection.Open();
            var totalorders = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close();

            var cus = db.Customers.Include("Orders").First(c => c.CustomerID == "SAVEA");
            Console.WriteLine("Actual Orders " + totalorders);
            Console.WriteLine("Filtered Orders " + cus.Orders.Count());

        }
    }
}
