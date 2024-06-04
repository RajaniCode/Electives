using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpAjaxRequest]
        [HttpGet]
        public ActionResult AjaxActionOnly()
        {
            return Json(string.Empty);
        }

        [Https]
        public ActionResult SslActionOnly()
        {
            return View();
        }
    }
}
