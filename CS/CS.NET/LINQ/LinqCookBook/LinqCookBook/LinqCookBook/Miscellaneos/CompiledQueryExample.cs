using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.Extensions;
using NorthWind.Business.EF.EagerLoading;
using System.Data.Objects;
using NorthWind.Business.EF;
using NorthWind.Business.EF.SelfReferencing;
using LinqCookBook.IncludeExample;
using System.Diagnostics;





namespace LinqCookBook.Miscellaneos
{
    public class Criteria
    {
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public string City { get; set; }
    }
    public class CompiledQueryExample
    {
        public static void Run()
        {
            CleanUp();
           // CompiledQueriesWithNoParametersAndDerivedTypes();
            //QueryWithParameters();
            //BuilderMethodsDoNotWork();
            //BuildingAdditionalQueryOnCompiledQuery();
            //ComplexType();
            //QueryReturningSingleEntity();
           //UsingIncludeWithMedia();
            //ReturningAnonymousType();
           // ReturningScalarValues();
            PassingMorethen3Parameters();
            //CompiledQueryPerformanceTest();
        }
        static readonly Func<IncludeTPTEntities, GunSmith> gunsmithquery =
              CompiledQuery.Compile<IncludeTPTEntities, GunSmith>(
                  (ctx) => ctx.Contacts.OfType<GunSmith>()
                              .Include("Company.Phone")
                              .Include("Company.Departments").First());
        public static void CompiledQueryPerformanceTest()
        {
            IncludeExample1.Cleaanup();
            IncludeExample1.InsertGunsmith();
            Console.WriteLine("None compiled query");
            var db = new IncludeTPTEntities();
            
            for (int i = 0; i < 10; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var gunsmith = db.Contacts.OfType<GunSmith>().Include("Company.Phone").Include("Company.Departments").First();
                stopwatch.Stop();
                Console.WriteLine("Iteration:{0} TimeTaken in millseconds:{1}", i, stopwatch.ElapsedMilliseconds);
            }

            
            Console.WriteLine("Compiled query");
            var db2 = new IncludeTPTEntities();

            for (int i = 0; i < 10; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var gunsmith = gunsmithquery(db2);
                stopwatch.Stop();
                Console.WriteLine("Iteration:{0} TimeTaken in millseconds:{1}", i, stopwatch.ElapsedMilliseconds);
            }
        }

        private static void PassingMorethen3Parameters()
        {
            var criteria = new Criteria{ Quantity = 50, Discount = 0, City = "London" };
            var ods = 
            CompiledQuery.Compile<NorthwindEFEntities, Criteria, IQueryable<OrderDetails>>(
                (db, search) => from od in db.OrderDetails
                                where od.Quantity > criteria.Quantity && od.Discount == criteria.Discount
                                && od.Orders.Customer.City == criteria.City
                                select od
                              );
            var entities = new NorthwindEFEntities();
            foreach (var od in ods(entities,criteria))
            {
                Console.WriteLine(od.OrderID);
            }

            //var db = new NorthwindEFEntities();
            //var ods = from od in db.OrderDetails
            //          where od.Quantity > criteria.Quantity && od.Discount == criteria.Discount
            //          && od.Orders.Customer.City == criteria.City
            //          select od;
            //foreach (var od in ods)
            //{
            //    Console.WriteLine(od.OrderID);
            //}
        }

        private static void ReturningScalarValues()
        {
            //total units ordered for all products
            var entities = new NorthwindEFEntities();
            var totalordered = CompiledQuery.Compile<NorthwindEFEntities, int>(
                (db) => db.Products.Where(p => p.UnitsInStock == 0)
                                    .Sum(p => p.UnitsOnOrder).Value);
            Console.WriteLine("Total units ordered: " + totalordered(entities));

        }

        private static void ReturningAnonymousType()
        {
            var entities = new NorthwindEFEntities();
            var summary = CompiledQuery.Compile((NorthwindEFEntities db) =>
                          from c in db.Customers
                          where c.City == "London"
                          select new
                          {
                              CustID = c.CustomerID,
                              TotalPurchases = c.Orders.SelectMany(o => o.OrderDetails).Sum(od => od.UnitPrice * od.Quantity)
                          });
            foreach (var cust in summary(entities))
            {
                Console.WriteLine("CustID:{0} Purchases:{1:C}",cust.CustID,cust.TotalPurchases);
            }
        }

        private static void UsingIncludeWithMedia()
        {
            var entities = new MediaSelfRefEntities();
            var categories = CompiledQuery.Compile<MediaSelfRefEntities, ObjectQuery<MediaCategory>>(
                            (db) => db.MediaCategories.Include("Medias"));
            foreach (var category in categories(entities))
            {
                Console.WriteLine("Category:{0} Total Medias:{1}",category.Name,category.Medias.Count());
            }
        }

        private static void QueryReturningSingleEntity()
        {
            var entities = new NorthwindEFEntities();
            var orderquery = CompiledQuery.Compile<NorthwindEFEntities, Order>(
                           (db) => db.Orders.First(o => o.OrderDate == db.Orders.Max(od => od.OrderDate)));
            Console.WriteLine(orderquery(entities).OrderDate);
            
        }

        private static void ComplexType()
        {
            CompiledQueryExample2.ComplexType();
        }

        private static void BuildingAdditionalQueryOnCompiledQuery()
        {
            CompiledQueryExample2.BuildingAdditionalQueryOnCompiledQuery();
        }

        private static void BuilderMethodsDoNotWork()
        {
            var entities = new NorthwindEFEntities();
            var customers = CompiledQuery.Compile<NorthwindEFEntities, ObjectQuery<Customer>>(
                (db) => db.Customers.Where("it.City = 'London'"));
            foreach (var cust in customers(entities))
            {
                Console.WriteLine(cust.CustomerID);
            }
        }

        private static void CleanUp()
        {
            var db = new EcommerceEntities();
            var cmd = db.CreateStoreCommand("delete Tradeshow where ShowId > 13;");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        private static void QueryWithParameters()
        {
            InsertShows();
            var entities = new EcommerceEntities();
            var tradeshows = CompiledQuery.Compile<EcommerceEntities, DateTime, DateTime, IQueryable<TradeShow>>(
                (db, startdate, enddate) => db.TradeShows
                                            .Where(s => s.StartDate >= startdate && s.EndDate <= enddate));
            var start = DateTime.Parse("1/1/05");
            var end = DateTime.Parse("1/1/08");
            foreach (var show in tradeshows(entities,start,end))
            {
                Console.WriteLine(show.Name);
            }
        }

        private static void InsertShows()
        {
            var entities = new EcommerceEntities();
            var show = new TradeShow { StartDate = DateTime.Parse("1/5/05"), EndDate = DateTime.Parse("7/7/06"), Name = "Computer show", Location = "xyz" };
            var show2 = new TradeShow { StartDate = DateTime.Parse("6/5/05"), EndDate = DateTime.Parse("3/4/06"), Name = "Music show", Location = "xyz1" };
            entities.AddToTradeShows(show);
            entities.AddToTradeShows(show2);
            entities.SaveChanges();
        }

        private static void CompiledQueriesWithNoParametersAndDerivedTypes()
        {
            var entities = new IncludeTPTEntities();
            var gunsmiths = CompiledQuery.Compile<IncludeTPTEntities, IQueryable<GunSmith>>(
                (db) => db.Contacts.OfType<GunSmith>()
                        .Where(g => g.Company.CompanyName.StartsWith("Food"))
                        .Select(g => g));
            
            Console.WriteLine(gunsmiths(entities).First().ContactName);
        }
    }
}
