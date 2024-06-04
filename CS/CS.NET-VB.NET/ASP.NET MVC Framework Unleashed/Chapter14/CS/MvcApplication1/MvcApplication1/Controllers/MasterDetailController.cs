using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{

    public class MasterDetailController : Controller
    {
        private ProductsDBEntities _entities = new ProductsDBEntities(); 

        public ActionResult Index()
        {
            return View(_entities.CategorySet.ToList());
        }


        public ActionResult Details(int id)
        {
            var products = from p in _entities.ProductSet
                           where p.CategoryId == id
                           select p;
            return PartialView("Details", products);
        }


    }
}
