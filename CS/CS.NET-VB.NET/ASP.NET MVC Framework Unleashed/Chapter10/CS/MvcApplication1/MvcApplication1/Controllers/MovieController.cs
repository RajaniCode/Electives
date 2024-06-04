using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class MovieController : ApplicationController
    {
         public ActionResult Index()
        {
            return View();
        }

    }
}
