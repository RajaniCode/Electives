using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;

namespace MvcApplication7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewModel.Message = "Welcome to ASP.NET MVC!";
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            ViewModel.Numbers = Enumerable.Range(0, 10);

            dynamic car = new ExpandoObject();
            car.Wheels = 4;
            car.Make = "Chevrolet";
            car.Model = "Camaro";
            ViewModel.Car = car;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
