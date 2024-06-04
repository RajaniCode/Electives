using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxUpdatesDemo.Models;

namespace AjaxUpdatesDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult PartialData(string change)
        {
            if (change == "1")
            {
                DemoModel dm = new DemoModel()
                {
                    userName = "def",
                    address = "5 street, marcia ave"
                };
                return View(dm);
            }
            else
            {
                DemoModel dm = new DemoModel()
                {
                    userName = "abc",
                    address = "1 street, vic ave"
                };
                return View(dm);
            }
           
        }

        [HttpPost]
        public ActionResult PartialData(DemoModel dm)
        {
            if (ModelState.IsValid)
            {
                return View(dm);
            }
            else
            {
            }
           
            return View(dm);
        }

    }
}
