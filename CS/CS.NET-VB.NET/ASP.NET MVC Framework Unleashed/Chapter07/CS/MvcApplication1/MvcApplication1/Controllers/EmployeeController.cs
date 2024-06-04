using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class EmployeeController : Controller
    {

        //
        // GET: /Employee/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Employee/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Employee employeeToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            // Add employee to database
            return RedirectToAction("Index");
        }

    }
}
