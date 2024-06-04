using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        Employee employee = null;
        public EmployeeController()
        {
            employee = new Employee();
            employee.Id = 1;
            employee.GivenName = "Malcolm";
            employee.Surname = "Sheridan";
            employee.Permanent = false;
            employee.Salary = 20000;
            employee.DateOfBirth = new DateTime(2000, 10, 17);
        }

        public ActionResult Index()
        {
            return View(employee);
        }

        public ActionResult SimpleView()
        {
            return View(employee);
        } 
    }
}
