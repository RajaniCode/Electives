using System;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var person = new Person
                             {
                                 Name = "Malcolm",
                                 Age = 30,
                                 DOB = new DateTime(2000, 1, 17),
                                 Married = true
                             };
            return View(person);
        }
    }
}
