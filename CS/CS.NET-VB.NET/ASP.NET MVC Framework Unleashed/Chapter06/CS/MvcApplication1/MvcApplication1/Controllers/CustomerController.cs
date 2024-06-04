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
        private CustomersDBEntities _entities = new CustomersDBEntities();

        public ActionResult Index()
        {
            ViewData["CustomerId"] = new SelectList(_entities.CustomerSet.ToList(), "Id", "LastName");
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }


        public ActionResult Details()
        {
            return View();
        }


        public ActionResult Delete()
        {
            return View();
        }


        public ActionResult List()
        {
            ViewData["Customers"] = from c in _entities.CustomerSet
                                    select c.LastName; 
            return View();
        }


    }
}
