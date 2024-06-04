using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Customer/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Customer customerToCreate)
        {
            // Add customer and address to database
            return RedirectToAction("Index");
        }

    }
}
