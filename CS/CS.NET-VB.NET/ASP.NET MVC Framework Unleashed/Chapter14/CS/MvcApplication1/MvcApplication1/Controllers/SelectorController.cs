using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{

    public class SelectorController : Controller
    {
        private ProductsDBEntities _entities = new ProductsDBEntities();

        public ActionResult Index()
        {
            var categories = _entities.CategorySet.ToList();
            var products = new List<Product>();
            return View(new ProductsVDM(categories, products));
        }

        [AcceptAjax]
        [ActionName("Details")]
        public ActionResult Details_Uplevel(int id)
        {
            var products = from p in _entities.ProductSet
                           where p.CategoryId == id
                           select p;

            return PartialView("Details", products);
        }

        [ActionName("Details")]
        public ActionResult Details_Downlevel(int id)
        {
            var categories = _entities.CategorySet.ToList();         
            var products = from p in _entities.ProductSet
                           where p.CategoryId == id
                           select p;

            return View("Index", new ProductsVDM(categories, products));
        }



    }
}
