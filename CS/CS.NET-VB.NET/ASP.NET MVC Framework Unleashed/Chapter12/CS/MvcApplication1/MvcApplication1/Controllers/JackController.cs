using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class JackController : Controller
    {
        [Authorize(Users="Jack")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
