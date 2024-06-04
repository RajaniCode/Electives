using System.Security.Principal;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class JillController : Controller
    {

        public ActionResult Index(IPrincipal user)
        {
            if (user.Identity.Name != "Jill")
                return new HttpUnauthorizedResult();

            return View();
        }

    }
}
