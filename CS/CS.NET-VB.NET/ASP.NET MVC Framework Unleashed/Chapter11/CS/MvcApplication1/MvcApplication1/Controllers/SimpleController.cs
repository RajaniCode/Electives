using System;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class SimpleController : Controller
    {
        [OutputCache(Duration=5,VaryByParam="none")]
        public string Time()
        {
            return DateTime.Now.ToString("T");
        }

    }
}
