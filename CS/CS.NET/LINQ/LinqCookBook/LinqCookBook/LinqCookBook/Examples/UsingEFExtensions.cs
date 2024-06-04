using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF;
using System.Data;
using Microsoft.Data.Extensions;
using System.Data.Objects;
namespace LinqCookBook.Examples
{
    public class UsingEFExtensions
    {
        private static void CleanUp()
        {
            var db = new NorthwindEFEntities();
            var cmd = db.CreateStoreCommand("delete Products where ProductName in ('MyProduct','Product2')");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        private static void SettingEntityReference()
        {
            var db = new NorthwindEFEntities();
            var product = new Product { ProductName = "MyProduct" };

            //creating beverage entity key.
            var beveragekey = new EntityKey("NorthwindEFEntities.Categories", "CategoryID", 1);
            product.CategoryReference.EntityKey = beveragekey;
            db.AddToProducts(product);
            db.SaveChanges();
            Console.WriteLine("ProductID: {0}", product.ProductID);

            var product2 = new Product { ProductName = "Product2" };
            db.ProductSet.InsertOnSaveChanges(product2);
            //allow setting key without meta data.
            product2.CategoryReference.SetKey(1);
            db.SaveChanges();
            //reading key value
            Console.WriteLine("Product CategoryId {0}", product2.CategoryReference.GetKey().ToString());
            //can also retrieve meta data and value back.
            Console.WriteLine("Category belongs to {0} EntitySet", product.CategoryReference.GetTargetEntitySet().Name);
        }
        private static void DynamicSql()
        {
            //get all categories using dynamic sql.
            var db = new NorthwindEFEntities();
            var categories = db.CreateStoreCommand("select * from categories").Materialize<Category>();
            Console.WriteLine("Total Categories {0} ", categories.Count());

            //returning plain clr type.
            var prods = db.CreateStoreCommand("select ProductID,ProductName from Products where CategoryID = 5")
                            .Materialize<ProductPartial>();
            Console.WriteLine("Total Partial Products " + prods.Count());

            //columns returned dont match with properties.
            var prods2 = db.CreateStoreCommand("select ProductID as ID,ProductName as Name from Products where CategoryID = 5")
                          .Materialize<ProductPartial>(r =>
                              new ProductPartial
                              {
                                  ProductID = r.Field<int>("ID"),
                                  ProductName = r.Field<string>("Name")
                              }
                              );

            //exeucting multiple resultset.
            IEnumerable<Suppliers> suppliers;
            IEnumerable<ProductPartial> prods3;
            
            var multiplecmd = db.CreateStoreCommand("dbo.EFExMultipleResult", CommandType.StoredProcedure);
            using (multiplecmd.Connection.CreateConnectionScope())
            using (var reader = multiplecmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                suppliers = multiplecmd.Materialize<Suppliers>();
                reader.NextResult();
                prods3 = multiplecmd.Materialize<ProductPartial>();
                reader.NextResult();
                // quanityordered = multiplecmd.ExecuteScalar();
            }
            Console.WriteLine("Results from multiplerestult set");
            Console.WriteLine("Total Suppliers {0}", suppliers.Count());
            Console.WriteLine("Total Products {0}", prods3.Count());
            
            
        }

        public static void UtilityMethods()
        {
            var db = new NorthwindEFEntities();
            var category = new Category { CategoryID = 1,CategoryName = "Beverages" };
            //no need for entitykey or entity container.
            db.CategorySet.Attach(category);
            Console.WriteLine(db.ObjectStateManager.GetObjectStateEntry(category).State);   
        }
        public static void VariousIQueryableExtensions()
        {
            var db = new NorthwindEFEntities();
            //using ToTraceString on IQueryable.
            IQueryable<Product> products = db.Products.Where(p => p.UnitPrice > 20).Take(10);
            Console.WriteLine(products.ToTraceString());
            //Products included with category
            var category = db.Categories.Take(2).Include("Products").First();
            Console.WriteLine("Total Products for category: " + category.Products.Count());

            ObjectQuery<Order> orders = GetOrdersForObjectQuery().AsObjectQuery().Where("it.ShipCity = 'London'");
            //using objectquery
            Console.WriteLine(orders.Count());
            ObjectQuery<Order> orders1 = GetOrdersThroughIQueryable().AsObjectQuery().Where("it.ShipCity = 'London'");
            Console.WriteLine(orders1.Count());
        }
        private static IQueryable<Order> GetOrdersForObjectQuery()
        {
            var db = new NorthwindEFEntities();
            return db.Orders.Where("it.ShipCountry = 'UK'");
        }
        private static IQueryable<Order> GetOrdersThroughIQueryable()
        {
            var db = new NorthwindEFEntities();
            return db.Orders.Where(o => o.ShipCountry == "UK");
        }
        public static void Run()
        {
            CleanUp();
            //SettingEntityReference();
            //DynamicSql();
            //UtilityMethods();
            VariousIQueryableExtensions();

           
        }
    }

    public class ProductPartial
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
}
