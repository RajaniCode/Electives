using System.Web.Mvc;
using MvcApplication1.CutomActionFilters;

namespace MvcApplication1.Controllers
{
    [Log]
    public class LogController : Controller
    {
 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

    }
}
