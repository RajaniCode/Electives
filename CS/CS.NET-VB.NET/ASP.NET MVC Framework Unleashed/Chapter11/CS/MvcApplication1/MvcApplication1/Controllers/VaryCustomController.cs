using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class VaryCustomController : Controller
    {
        [OutputCache(Duration=9999, VaryByParam="None", VaryByCustom="JS")]
        public ActionResult Index()
        {
            if (Request.Browser.EcmaScriptVersion.Major > 0) 
                return View("IndexJS");
        
            return View("Index");

        }

    }
}
