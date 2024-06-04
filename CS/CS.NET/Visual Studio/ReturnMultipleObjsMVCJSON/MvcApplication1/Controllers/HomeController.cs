using System.Linq;
using System.Web.Mvc;
using System;
using System.Collections;
using System.Globalization;

namespace MvcApplication1.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult ReturnMultipleObjects()
        {
            var info = new DateTimeFormatInfo();
            return Json(new
                            {
                                EnvironmentVariables = (from p in Environment.GetEnvironmentVariables().Cast<DictionaryEntry>()
                                                        select new TextValue()
                                                           {
                                                               Text = p.Value.ToString(),
                                                               Value = p.Key.ToString()
                                                           }),
                                MonthsInYear = (from p in Enumerable.Range(1, 12)
                                                select new TextValue
                                                {
                                                    Value = p.ToString(),
                                                    Text = info.GetMonthName(p)
                                                })
                            }
                    );
        }
    }

    public class TextValue
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
