using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class PersonController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");
            return View("Details");
        }

    }
}
