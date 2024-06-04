using System.Web.Mvc;
using System.Web.Security;

namespace MvcApplication1.Controllers
{
    public class LookupController : Controller
    {

        public ActionResult Index(string search)
        {
            MembershipUserCollection users = new MembershipUserCollection();
            if (!string.IsNullOrEmpty(search))
                users = Membership.FindUsersByName("%" + search + "%");
            
            return View(users);
        }

    }
}
