using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Numbers"] = GenerateNumbers();
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetListViaJson()
        {
            return Json(GenerateNumbers());
        }

        private static List<SelectListItem> GenerateNumbers()
        {
            var numbers = (from p in Enumerable.Range(0, 20)
                            select new SelectListItem
                            {
                                Text = p.ToString(),
                                Value = p.ToString()
                            });
            return numbers.ToList();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
