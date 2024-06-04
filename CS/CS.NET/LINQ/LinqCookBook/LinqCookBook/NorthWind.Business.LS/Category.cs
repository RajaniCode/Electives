using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace NorthWind.Business.LS
{
    public partial class Category
    {
        public static void DeleteCategoryExample()
        {
            var db = new NorthWindDataContext();
            DataLoadOptions op = new DataLoadOptions();
            op.LoadWith<Category>(c => c.Products);
            db.LoadOptions = op;
            var beverage = db.Categories
                            .First(c => c.CategoryName == "Beverages");

            Console.WriteLine("total orders for AFKI customer " + beverage.Products.Count());
            var firstproduct = beverage.Products.First();
            db.Products.DeleteOnSubmit(firstproduct);
            Console.WriteLine("Total orders after marking for deletion " + beverage.Products.Count());
        }
    }
}
