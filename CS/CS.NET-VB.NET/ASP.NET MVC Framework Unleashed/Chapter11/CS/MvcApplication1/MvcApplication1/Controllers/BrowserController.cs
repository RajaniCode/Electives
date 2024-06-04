using System;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class BrowserController : Controller
    {
        [OutputCache(Duration=999, VaryByParam="None", VaryByCustom="Browser")]
        public string Index()
        {
            return DateTime.Now.ToString("T") + ":" + Request.UserAgent;
        }

    }
}
