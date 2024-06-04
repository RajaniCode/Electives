using System.Web.Mvc;
using System.ComponentModel;

namespace Demo.Controllers
{
    public class CarsController : Controller
    {
        //
        // GET: /Cars/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Make([DefaultValue("Holden")] string make, 
                                 string model)
        {
            return View();
        }
    }
}
