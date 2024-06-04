using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductHiearachy;
using Microsoft.Data.Extensions;

namespace LinqCookBook.Inheritance
{
    public class ProductExample
    {
        public static void CleanUp()
        {
            var db = new ProductsHiearchyEntities();
            var cmd = db.CreateStoreCommand("delete tph.Product;delete tph.ChristmasSpecials");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public static void Run()
        {
            var db = new ProductsHiearchyEntities();
            var discontinued = new DiscontinuedProduct { Name = "Discontinued", Price = 50 };
            var product = new Product { Name = "T shirt", Price = 30 };
            var christmasspecial = new ChristmasSpecials { Name = "Chrimas Tree", Price = 55, ChrismasDiscount = 20 };
            db.AddToProduct(discontinued);
            db.AddToProduct(product);
            db.AddToProduct(christmasspecial);
            db.SaveChanges();
        }
    }
}
