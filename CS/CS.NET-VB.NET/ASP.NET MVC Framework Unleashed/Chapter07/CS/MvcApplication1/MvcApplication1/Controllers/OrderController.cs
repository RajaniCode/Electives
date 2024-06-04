using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class OrderController : Controller
    {

        //
        // GET: /Order/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Order/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Address shipping, Address billing)
        {
            // Insert into database
            return RedirectToAction("Index");
        }


    }
}
