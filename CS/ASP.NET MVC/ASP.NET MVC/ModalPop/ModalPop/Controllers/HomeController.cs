using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using ModalPop.Models;

namespace ModalPop.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [AcceptAjax]
        public PartialViewResult RandomPopupView()
        {
            var model = new ModalModel() { SomeString = "PIE!!!" };
            return PartialView("RandomModal", model);
        }

        [AcceptAjax]
        public PartialViewResult RandomDetailsPopupView(string recnum)
        {
            var model = new ModalModel();
            model.SomeString = string.Format("Looks like you clicked on row for record number {0}", recnum);
            return PartialView("RandomModal", model);
        }
    }
}
