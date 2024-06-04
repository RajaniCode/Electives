using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Objects;
using NorthWind.Business.EF.functions;
using System.Data.Common;

namespace LinqCookBook.Functions
{
    public class Info
    {
        public string custid { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalPurchases { get; set; }
    }
    public class FunctionExamples
    {
        public static void CallingFunctionsUsinEsql()
        {
            //written in esql
            var db = new NWFunctions();
            string esql =
                @"select custid,count(o.OrderID) as TotalOrders,sum(NWFunctionModel.Store.OrderTotal(o.OrderID)) as TotalPurchases
                from NWFunctions.Orders as o
                where NWFunctionModel.Store.OrderTotal(o.OrderID) > 
                anyelement(
                  select value avg(NWFunctionModel.Store.OrderTotal(od1.OrderID)) from NWFunctions.Orders as od1
                )
                and NWFunctionModel.Store.GetDiscount(o.Customer.CustomerID) < 5
                group by o.Customer.CustomerID as custid
                having count(o.OrderID) > 7
                order by TotalPurchases,TotalOrders";

            var results = db.CreateQuery<DbDataRecord>(esql);
            Console.WriteLine("CustomerID\t TotalOrders\t TotalPurchases\r\n");
            foreach (var custinfo in results)
            {
                Console.WriteLine("{0}\t\t {1}\t\t {2}",
                    custinfo["custid"].ToString(),
                    custinfo["TotalOrders"].ToString(),
                    custinfo["TotalPurchases"].ToString());
            }
        }
        
        public static void CallingFunctionsInLinqToEntities()
        {
            var db = new NWFunctions();
            var result = db.Orders
                            .Where(@"
                            NWFunctionModel.Store.OrderTotal(it.OrderID) > 
                            anyelement(
                                        select value avg(NWFunctionModel.Store.OrderTotal(od1.OrderID)) 
                                        from NWFunctions.Orders as od1
                                      )
                            and NWFunctionModel.Store.GetDiscount(it.Customer.CustomerID) < 5
                                ")
                        .GroupBy("it.Customer.CustomerID as custid",
                        "custid,count(it.OrderID) as TotalOrders,sum(NWFunctionModel.Store.OrderTotal(it.OrderID)) as TotalPurchases")
                        .Where("it.TotalOrders > 7")
                        .OrderBy("it.TotalPurchases,it.TotalOrders");
                
                        

            Console.WriteLine("CustomerID\t TotalOrders\t TotalPurchases\r\n");
            foreach (var custinfo in result)
            {
                Console.WriteLine("{0}\t\t {1}\t\t {2}",
                    custinfo["custid"].ToString(),
                    custinfo["TotalOrders"].ToString(),
                    custinfo["TotalPurchases"].ToString());
            }


//            select NWFunctionModel.Store.ISDATE('1/1/2008'),NWFunctionModel.Store.ISNULL(null,0),
//NWFunctionModel.Store.RAND(100) * 100,
//NWFunctionModel.Store.COALESCE(null,'N/A')
//from {1}


        }
    }
}
