using System;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class ProfileController : Controller
    {
        [OutputCache(CacheProfile="Profile1")]
        public string Index()
        {
            return DateTime.Now.ToString("T");
        }

    }
}
