using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF;
using NorthWind.Business.EF.LazyLoading;
using NorthWind.Business.EF.EagerLoading;
using NorthWind.Business.EF.ManyToManyRelationship;
using Microsoft.Data.Extensions;
using NorthWind.Business.EF.SelfReferencing;
using SFCTE;

using System.Data.Objects;
using NorthWind.Business.EF.NorthWindFull;
using NorthWind.Business.EF.OneToMany;

namespace LinqCookBook.IncludeExample
{
    public class IncludeExample1
    {
        public static void Run()
        {
            Cleaanup();
            //Example1();
           // Example2();
           // Example3();
            //Example4();
            //Example5();
           // Example6();
            //Example7();
            IncludeExample2.Run();

            //Example8();
           // Example9();
            //Example10();
            //Example11();
            Example12();
        }

        private static void Example12()
        {
            var db = new OneToManyEntities();
            var customer = db.Customer
                              .Include("Addresses")
                              .First(c => c.ContactName == "Zeeshan");
            
            Console.WriteLine("Customer:{0} Total Addresses:{1}",
                customer.ContactName,customer.Addresses.Count());

        }

        

        private static void Example11()
        {
            var db = new NorthwindFullEntities();
            var cat = from c in db.Categories
                      where c.CategoryName == "Beverages"
                      select new
                      {
                          Category = c,
                          Products = c.Products.Where(p => p.Suppliers.SupplierID == 1)
                      };
            var beverage = cat.Select(c => c.Category).First();
            //attach the product to the category
            var prods = cat.SelectMany(c => c.Products).AsEnumerable();
            beverage.Products.Attach(prods);
            
            Console.WriteLine("Category:{0} TotalProducts:{1}",
                beverage.CategoryName,beverage.Products.Count());
        }

        private static void Example10()
        {
            var db = new NorthwindFullEntities();
            var ods = from od in db.Order_Details
                      join o in db.Orders on od.OrderID equals o.OrderID
                      where o.ShipCity == "Caracas"
                      select od;
            ods = ods.Include("Products");
            foreach (var od in ods)
            {
                Console.WriteLine("Product:{0} Quantity:{1}",od.Products.ProductName,od.Quantity);
            }
        }

        private static void Example9()
        {
            //nested from clause would also cause the include to get lost
            var db = new NorthwindFullEntities();
            //var orders = from o in db.Orders.Include("Customer")
            //             from od in o.Order_Details
            //             where od.Quantity > 120
            //             select o;

            var orders = from o in db.Orders
                         from od in o.Order_Details
                         where od.Quantity > 120
                         select o;
            orders = orders.Include("Customer");
            foreach (var order in orders)
            {
                Console.WriteLine("OrderID:{0} Customer:{1}",order.OrderID,order.Customer.ContactName);
            }
        }

        private static void Example8()
        {
            var db = new NorthwindEFEntities();
            //incorrect query Include is lost
            //var prods = from p in db.Products.Include("Category")
            //            group p by p.Category.CategoryID into g
            //            select g.FirstOrDefault(p1 => p1.UnitPrice == g.Max(p2 => p2.UnitPrice));

            var prods = from p in db.Products
                        group p by p.Category.CategoryID into g
                        select g.FirstOrDefault(p1 => p1.UnitPrice == g.Max(p2 => p2.UnitPrice));
            prods = prods.Include("Category");
            foreach (var product in prods)
            {
                Console.WriteLine("Product:{0} Category:{1}",product.ProductName,product.Category.CategoryName);
            }
        }

       

        private static void Example7()
        {
            var db = new SFCTEPHEntities();
            var president = db.Employees
                              .Include("Employees.Employees.Employees")
                              .First(e => e.ReportsTo == null);
            Console.WriteLine("President:{0}",president.Name);
           var manager = president.Employees.OfType<SFCTE.Manager>().First();
            Console.WriteLine("Manager:{0}",manager.Name);
            var supervisor = manager.Employees.OfType<SFCTE.Supervisor>().First();
            Console.WriteLine("Supervisor:{0}",supervisor.Name);
            foreach (var agent in supervisor.Employees.OfType<SFCTE.SalesAgent>())
            {
                Console.WriteLine("SalesAgent:{0}",agent.Name);   
            }


        }

        private static void Example6()
        {
            var db = new MediaSelfRefEntities();
            var gunhistory  = db.MediaCategories
                                .Include("Medias")
                                .Include("SubCategories.Medias")
                                .First(mc => mc.Name == "Gun History");

            Console.WriteLine("Category:{0} Total Medias:{1}",gunhistory.Name,gunhistory.Medias.Count());
            Console.WriteLine("   SubCategories");
            foreach (var subcategory in gunhistory.SubCategories)
            {
                Console.WriteLine("   Category:{0} TotalMedias:{1}",subcategory.Name,subcategory.Medias.Count());
            }

        }

        public static void Cleaanup()
        {
           
        }

        private static void Example5()
        {
            var db = new MultipleAssocationsEntities();
            var actor = db.Actors
                          .Include("MoviesWithLeadingActor")
                          .Include("MoviesWithSupportingRole").First();
            Console.WriteLine("Actor:{0} TotalMoviesWithLead:{1} TotalMoviesWithSupport:{2}",
                actor.Name,actor.MoviesWithLeadingActor.Count(),actor.MoviesWithSupportingRole.Count());
        }

        private static void Example4()
        {
            InsertGunsmith();
            var db = new IncludeTPTEntities();
            var gunsmith = db.Contacts.OfType<GunSmith>().Include("Company.Phone").Include("Company.Departments").First();
            Console.WriteLine("Name:{0} Company:{1} Phone:{2} Departments:{3}",
                gunsmith.ContactName, gunsmith.Company.CompanyName,
                gunsmith.Company.Phone.Number, gunsmith.Company.Departments.Count());
        }

        public static void InsertGunsmith()
        {
            var db = new IncludeTPTEntities();
            var gunsmith = new GunSmith
            {
                ContactName = "Zeeshan",
                Email = "zeeshanjhirani@gmail.com",
                IsCertified = true,
                Company = new Company
                {
                    CompanyName = "Food LTD",
                    Address = "address xyz",
                    Phone = new Phone { Number = "123-456-9899" },
                    Departments =
                    {
                        new Department{Name="Finance"},
                        new Department{Name="Marketing"}
                    }
                }
            };
            db.AddToContacts(gunsmith);
            db.SaveChanges();
        }

        private static void Example3()
        {
            var db = new LazyLoadingEntities();
            var orders = from o in db.Orders.Include("Customer").Include("OrderDetails.Products")
                         where o.ShipCity == "Caracas"
                         select o;
            foreach (var order in orders)
            {
                Console.WriteLine("OrdID:{0} Customer:{1} TotalDetails:{2} TotalProducts:{3}",
                    order.OrderID, order.Customer.ContactTitle, order.OrderDetails.Count(),
                    order.OrderDetails.Select(od => od.Products.ProductID).Count()
                    );  
            }
        }

        private static void Example2()
        {
            var db = new NorthwindEFEntities();
            var prods = from p in db.Products.Include("Category").Include("Supplier").Include("OrderDetails")
                        where p.UnitPrice > 50.0M
                        select p;
            foreach (var prod in prods)
            {
                Console.WriteLine("ProdID:{0}\tCategory:{1}\tSupplier:{2}\tODS Count:{3}",
                    prod.ProductID,prod.Category.CategoryName,prod.Supplier.ContactName,
                    prod.OrderDetails.Count());
            }
        }

        private static void Example1()
        {
            var db = new NorthwindEFEntities();
            var custs = db.Customers.Include("Orders");
            foreach (var cus in custs)
            {
                Console.WriteLine(cus.ContactName + " Orders:" + cus.Orders.Count());
            }
        }
    }
}
