using System.Web.Mvc;
using System.Web.UI;

namespace MvcApplication1.Controllers
{
    public class UserController : Controller
    {
        [OutputCache(Duration=9999, VaryByParam="None", Location=OutputCacheLocation.Client)]
        public string Index()
        {
            return User.Identity.Name;
        }

    }
}
