using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthWind.Business.EF
{
    public partial class Category
    {
        public static void DeleteCategoryExample()
        {
            var db = new NorthwindEFEntities();
            var beverage = db.Categories.Include("Products")
                            .First(c => c.CategoryName == "Beverages");

            Console.WriteLine("total orders for AFKI customer " + beverage.Products.Count());
            var firstproduct = beverage.Products.First();
            db.DeleteObject(firstproduct);
            Console.WriteLine("Total orders after marking for deletion " + beverage.Products.Count());
        }
    }
}
