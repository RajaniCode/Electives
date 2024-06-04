using System.Web.Mvc;
using System;

namespace MvcApplication1.Controllers
{
    public class UserController : Controller
    {

        public ActionResult Index()
        {
            // Show ManagerView view to members of Manager role
            if (User.IsInRole("Manager"))
                return View("ManagerView");

            // Show JackView to Jack (and no one else)
            if (string.Equals(User.Identity.Name, "Jack", StringComparison.CurrentCultureIgnoreCase))
                return View("JackView");

            // Show AuthenticatedView to non-anonymous visitors
            if (User.Identity.IsAuthenticated)
                return View("AuthenticatedView");

            // Otherwise, redirect to LogOn action
            return RedirectToAction("LogOn", "Account");
        }

    }
}
