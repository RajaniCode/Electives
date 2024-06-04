using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class WidgetController : Controller
    {

        //
        // GET: /Widget/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Widget/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Widget widgetToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            // Insert widget into database

            return RedirectToAction("Index");
        }


    }
}
