using System.Collections.Generic;
using System.Web.Mvc;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Cars"] = new MultiSelectList(Car.GetCars(), "Id", "Make");
            return View("Index2");
        }

        [HttpPost]
        [ValidateAntiForgeryToken(Salt = "Cars")]
        public ActionResult PostCars([ModelBinder(typeof(SelectListModelBinder))] List<Car> cars)
        {
            return Content("Ok");
        }
    }
}
