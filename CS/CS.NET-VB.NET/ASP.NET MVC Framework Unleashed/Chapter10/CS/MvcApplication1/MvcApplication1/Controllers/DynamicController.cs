using System;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class DynamicController : Controller
    {
        public ActionResult Index()
        {
            // Randomly select master page
            var rnd = new Random();
            var masterPage = "Dynamic" + rnd.Next(2);

            // Return view with master page
            return View("Index", masterPage);
        }

    }
}
