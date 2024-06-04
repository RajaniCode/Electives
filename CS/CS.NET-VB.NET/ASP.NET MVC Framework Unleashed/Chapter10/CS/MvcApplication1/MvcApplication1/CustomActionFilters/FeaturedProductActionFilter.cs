using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.CustomActionFilters
{
    public class FeaturedProductAttribute: ActionFilterAttribute
    {
        private ProductsDBEntities _entities = new ProductsDBEntities(); 

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewData = filterContext.Controller.ViewData;
            viewData["featured"] = GetRandomProducts();
        }

        private IList<Product> GetRandomProducts()
        {
            var rnd = new Random();
            var allProducts = _entities.ProductSet.ToList();
            var featuredProducts = new List<Product>();
            for (int i = 0; i < 3; i++)
            {
                var product = allProducts[rnd.Next(allProducts.Count)];
                allProducts.Remove(product);
                featuredProducts.Add(product);
            }
            return featuredProducts;
        }

    }
}
