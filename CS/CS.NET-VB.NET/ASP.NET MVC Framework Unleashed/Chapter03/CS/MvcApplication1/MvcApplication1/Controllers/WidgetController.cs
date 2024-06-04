using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class WidgetController : Controller
    {
        //
        // GET: /Widget/

        public ActionResult Index()
        {
            return View();
        }


        //
        // POST: /Widget/Create

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index", "ProductController");

            return View();
        }



    }
}
