using System.Management;
using System.Web.Mvc;
using System.Linq;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        [OutputCache(Duration = 60, VaryByParam = "*")]
        public ActionResult Index()
        {
            var mcServices = new ManagementClass("Win32_Service");
            var services = (from p in mcServices.GetInstances().OfType<ManagementObject>()
                        select new ServiceData
                        {
                            Description = p.GetPropertyValue("Description") as string,
                            Caption = p.GetPropertyValue("Caption").ToString()
                        }).ToList();
            return View(services);
        }
    }
}
