using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.Extensions;
using NorthWind.Business.EF.Inheritance;


namespace LinqCookBook.Inheritance
{
    public class TPCAuditExample
    {
        static void CleanUp()
        {
            var db = new AuditTPCEntities();
            var cmd = db.CreateStoreCommand("delete tpt.Categories; delete tpt.Products;");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }

        public static void Run()
        {
            CleanUp();
            Example();
        }

        private static void Example()
        {
            var db = new AuditTPCEntities();
            var category = new Category
            {
                Name = "Cat1",
                CreateDate = DateTime.Today,
                CreatedBy = "zhirani",
                ModifiedDate = DateTime.Today
            };
            var product = new Product
            {
                Name = "prod1",
                CreateDate = DateTime.Today,
                ModifiedDate = DateTime.Today,
                CreatedBy = "zhirani",
            };
            category.Products.Add(product);
            db.AddToCategories(category);
            db.SaveChanges();

            var db2 = new AuditTPCEntities();
            var prod = db2.Products.Include("Category").First(p => p.Name == "prod1");
            Console.WriteLine("Product {0} Category {1}", prod.Name, prod.Category.Name);
        }
    }
}
