using System;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class NewsController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Refresh()
        {
            var partial = "";
            var rnd = new Random();
            switch (rnd.Next(2))
            {
                case 0:
                    partial = "News/News1";
                    break;
                case 1:
                    partial = "News/News2";
                    break;
            }

            return PartialView(partial);
        }

    }
}
