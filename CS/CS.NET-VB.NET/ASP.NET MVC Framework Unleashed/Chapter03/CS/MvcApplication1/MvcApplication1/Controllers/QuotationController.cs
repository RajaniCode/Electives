using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class QuotationController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            var quotes = new List<string>
            {
                "Look before you leap",
                "The early bird gets the worm",
                "All hat, no cattle"
            };
            
            return Json(quotes);
        }

    }
}
