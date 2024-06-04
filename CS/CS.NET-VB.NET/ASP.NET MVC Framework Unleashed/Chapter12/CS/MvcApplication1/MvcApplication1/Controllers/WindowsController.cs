using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class WindowsController : Controller
    {
        [Authorize(Users="redmond\\swalther")]
        public ActionResult Index()
        {
            ViewData["userName"] = User.Identity.Name;
            return View();
        }

        [Authorize(Roles = "Managers")]
        public ActionResult SalesFigures()
        {
            ViewData["userName"] = User.Identity.Name;
            return View();
        }

        public ActionResult SecretStuff()
        {
            if (User.IsInRole("Managers"))
                return View();

            return new HttpUnauthorizedResult();
        }



    }
}
