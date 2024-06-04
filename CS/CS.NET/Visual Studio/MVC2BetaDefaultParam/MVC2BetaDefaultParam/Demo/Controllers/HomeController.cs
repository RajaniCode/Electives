using System.Web.Mvc;
using System.ComponentModel;

namespace Demo.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }
        
        public ActionResult About()
        {
            return View();
        }
    }
}
