using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class ProductController : Controller
    {
        private ToyStoreDBEntities _entities = new ToyStoreDBEntities();

        public ActionResult Index()
        {
            return View(_entities.ProductSet.ToList());
        }

        public ActionResult Index2()
        {
            return View(_entities.ProductSet.ToList());
        }
    }
}
