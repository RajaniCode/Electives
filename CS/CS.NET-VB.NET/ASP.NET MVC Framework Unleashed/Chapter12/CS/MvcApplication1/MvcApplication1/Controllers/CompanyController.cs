using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class CompanyController : Controller
    {
        [Authorize]
        public ActionResult Secrets()
        {
            return View();
        }

        [Authorize(Users="Jack,Jill")]
        public ActionResult SuperSecrets()
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        public ActionResult SuperSuperSecrets()
        {
            return View();
        }


    }
}
