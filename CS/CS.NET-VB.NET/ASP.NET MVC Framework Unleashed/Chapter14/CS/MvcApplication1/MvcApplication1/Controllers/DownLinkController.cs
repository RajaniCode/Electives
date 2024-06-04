using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{

    public class ProductsVDM
    {
        public ProductsVDM(IEnumerable<Category> categories, IEnumerable<Product> products)
        {
            this.Categories = categories;
            this.Products = products;
        }

        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }

    public class DownLinkController : Controller
    {
        private ProductsDBEntities _entities = new ProductsDBEntities();

        public ActionResult Index()
        {
            var categories = _entities.CategorySet.ToList();
            var products = new List<Product>();
            return View(new ProductsVDM(categories, products));
        }


        public ActionResult Details(int id)
        {
            var products = from p in _entities.ProductSet
                           where p.CategoryId == id
                           select p;

            if (Request.IsAjaxRequest())
            {
                return PartialView("Details", products);
            }
            else
            {
                var categories = _entities.CategorySet.ToList();
                return View("Index", new ProductsVDM(categories, products));
            }

        }


    }
}
