using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeRepository _repository = new EmployeeRepository();

        // GET: /Employee/
        public ActionResult Index()
        {
            return View();
        } 

        // GET: /Employee/Create
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            return View();
        } 

        // POST: /Employee/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Employee employeeToCreate)
        {
            try
            {
                _repository.InsertEmployee(employeeToCreate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: /Employee/Delete/1
        [AcceptVerbs(HttpVerbs.Delete)]
        public ActionResult Delete(int id)
        {
            _repository.DeleteEmployee(id);
            return Json(true);
        }

    }
}
