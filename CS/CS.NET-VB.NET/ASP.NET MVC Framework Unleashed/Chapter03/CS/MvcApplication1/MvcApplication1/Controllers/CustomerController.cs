using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class CustomerController : Controller
    {

        public ActionResult Details()
        {
            return View("Details");
        }

    }
}
