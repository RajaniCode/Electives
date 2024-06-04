using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxFormsDemo.Models;

namespace AjaxFormsDemo.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        public ActionResult Index()
        {
            var data = from c in db.Customers
                       where c.CustomerID == "ALFKI"
                       select c;
            return View(data.SingleOrDefault());
        }

        [HttpPost]
        public string ProcessForm(Customer obj)
        {
            var data = from c in db.Customers
                       where c.CustomerID == obj.CustomerID
                       select c;
            Customer cust = data.SingleOrDefault();
            cust.CompanyName = obj.CompanyName;
            db.SaveChanges();
            return "<h2>Customer updated successfully!</h2>";
        }

        [HttpPost]
        public string ProcessLink()
        {
            return "<h2>This is a response from action method!</h2>";
        }
    }
}
