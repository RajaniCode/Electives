using System;
using System.Linq;
using System.Web.Mvc;
using System.Dynamic;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GetTimeZones()
        {
            dynamic viewData = new ExpandoObject();
            viewData.TimeZones = from p in TimeZoneInfo.GetSystemTimeZones() 
                                 select new SelectListItem
                                 {
                                    Text = p.DisplayName,
                                    Value = p.Id
                                 };
            return View("Index", viewData);
        }
    }
}
