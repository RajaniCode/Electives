using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Security.Application;

namespace SecurityFilters.Controllers
{
    public class RegisteredController : Controller
    {
        //
        // GET: /Registered/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MyAge()
        {
            var age = Convert.ToString(Session["age"]);
            return View(Session["age"]);
        }

        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public ActionResult MyAge(string age)
        {
            Session["age"] = age;
            return View(Session["age"]);
        }

        [HttpGet]
        public ActionResult Profile()
        {
            var age = Convert.ToString(Session["profile"]);
            return View(Session["profile"]);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Profile(string profile)
        {
            Session["profile"] = Sanitizer.GetSafeHtmlFragment(profile)
                                            .Replace("=\"x_","=\"")
                                            .Replace(".x_", ".");
            return View(Session["profile"]);
        }

    }
}
