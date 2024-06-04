using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class TestController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }



        public ActionResult ProductArray(Product[] products)
        {
            return RedirectToAction("Index");
        }




    }
}
