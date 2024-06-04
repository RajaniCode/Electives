using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MvcApplication1.Controllers
{
    public class RemoveController : Controller
    {
        [OutputCache(Duration=9999, VaryByParam="None", Location=OutputCacheLocation.Server)]
        public ActionResult Time()
        {
            return View();
        }

        public ActionResult Clear()
        {
            HttpResponse.RemoveOutputCacheItem("/Remove/Time");
            return RedirectToAction("Time");
        }


    }
}
