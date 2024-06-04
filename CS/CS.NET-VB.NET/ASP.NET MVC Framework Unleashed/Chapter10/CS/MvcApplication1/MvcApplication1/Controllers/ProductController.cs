using System.Web.Mvc;
using MvcApplication1.CustomActionFilters;

namespace MvcApplication1.Controllers
{
    public class ProductController : Controller
    {

        [FeaturedProduct]
        public ActionResult Index()
        {
            return View();
        }

        [FeaturedProduct]
        public ActionResult Details()
        {
            return View();
        }

    
        public ActionResult About()
        {
            return View();
        }

    }
}
