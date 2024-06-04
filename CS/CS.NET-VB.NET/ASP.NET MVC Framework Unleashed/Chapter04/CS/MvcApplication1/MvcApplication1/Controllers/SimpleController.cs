using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class SimpleController : Controller
    {
        public ActionResult Index()
        {
            ViewData["message"] = "Hello World!";
            return View();
        }
    }
}
