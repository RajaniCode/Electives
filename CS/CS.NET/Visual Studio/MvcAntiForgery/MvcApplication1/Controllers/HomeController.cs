using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken(Salt = "DynamicToken")]
        public void SubmitForm(FormCollection collection)
        {
            var col = collection;
        }
    }
}
