using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class BankController : Controller
    {
        //
        // GET: /Bank/Withdraw

        public ActionResult Withdraw()
        {
            return View();
        }

        //
        // POST: /Bank/Withdraw
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Withdraw(decimal amount)
        {
            // Perform withdrawal
            return View();
        }

    }
}
