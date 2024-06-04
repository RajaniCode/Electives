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
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            return View();
        }

        public ActionResult EmployeeView()
        {
            var employee = new Employee();
            employee.Id = 1;
            employee.GivenName = "Malcolm";
            employee.Surname = "Sheridan";
            employee.Permanent = false;
            employee.Salary = 20000;
            employee.DateOfBirth = new DateTime(2000, 10, 17);
            return View(employee);
        }        
    }
}
