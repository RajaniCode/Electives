using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class SurveyController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(List<string> source)
        {
            return View();
        }

    }
}
