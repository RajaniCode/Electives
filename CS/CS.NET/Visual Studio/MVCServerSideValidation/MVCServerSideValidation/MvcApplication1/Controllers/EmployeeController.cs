using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class EmployeeController : Controller
    {        
        public ActionResult Index()
        {
            var employee = new Employee();
            return View(employee.FetchEmployees());
        }

        public ActionResult Edit(int id)
        {
            var employee = new Employee();
            return View(employee.FetchEmployee(id));
        }                

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {                
                if (!ModelState.IsValid)
                    return View(employee);
                else
                    // update data here...
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
