using System;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class CacheControlController : Controller
    {
        public string Index()
        {
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Response.Cache.SetMaxAge(TimeSpan.FromSeconds(10));
            return DateTime.Now.ToString("T") + " <a href='/CacheControl/Index'>link</a>";
        }

    }
}
