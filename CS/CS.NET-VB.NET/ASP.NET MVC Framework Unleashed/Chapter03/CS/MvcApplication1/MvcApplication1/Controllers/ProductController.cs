using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Product/Help

        public ActionResult Help()
        {
            return View();
        }

        //
        // GET: /Details/1

        public ActionResult Details(int Id)
        {
            return View();
        }


    }
}
