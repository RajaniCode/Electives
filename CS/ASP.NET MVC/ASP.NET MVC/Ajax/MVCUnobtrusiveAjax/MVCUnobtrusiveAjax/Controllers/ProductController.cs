using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCUnobtrusiveAjax.Models;

namespace MVCUnobtrusiveAjax.Controllers
{
    public class ProductController : Controller
    {
        private Product[] products = {
                                         new Product { 
                                             ProductId = 1, Name = "Audi A3",
                                             Description = "New Audi A3", Category = Category.Car,
                                             Price = 25000
                                         },
                                         new Product { 
                                             ProductId = 2, Name = "VW Golf",
                                             Description = "New VW Golf", Category = Category.Car,
                                             Price = 22000
                                         },
                                         new Product { 
                                             ProductId = 3, Name = "Boing 747",
                                             Description = "The new Boing airplane", Category = Category.Airplane,
                                             Price = 2000000
                                         },
                                         new Product { 
                                             ProductId = 4, Name = "Boing 747",
                                             Description = "The new Boing airplane", Category = Category.Airplane,
                                             Price = 2000000
                                         },
                                         new Product { 
                                             ProductId = 5, Name = "Yamaha 250",
                                             Description = "Yamaha's new motorcycle", Category = Category.Motorcycle,
                                             Price = 5000
                                         },
                                         new Product { 
                                             ProductId = 6, Name = "honda 750",
                                             Description = "Honda's new motorcycle", Category = Category.Motorcycle,
                                             Price = 7000
                                         }

                                     };

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetProductData(string selectedCategory = "All")
        {
            IEnumerable<Product> data = products;
            if (selectedCategory != "All")
            {
                Category selected = (Category)Enum.Parse(typeof(Category), selectedCategory);
                data = products.Where(p => p.Category == selected);
            }
            return PartialView(data);
        }

        public ActionResult GetProducts(string selectedCategory = "All")
        {
            return View((object)selectedCategory);
        }

        //public ActionResult GetProducts()
        //{
        //    return View(products);
        //}

        //[HttpPost]
        //public ActionResult GetProducts(string selectedCategory)
        //{
        //    if (selectedCategory == null || selectedCategory == "All")
        //    {
        //        return View(products);
        //    }
        //    else
        //    {
        //        Category selected = (Category)Enum.Parse(typeof(Category), selectedCategory);
        //        return View(products.Where(p => p.Category == selected));
        //    }
        //}

    }
}
