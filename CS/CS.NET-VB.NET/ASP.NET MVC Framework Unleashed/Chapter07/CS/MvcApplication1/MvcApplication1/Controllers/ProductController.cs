using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class ProductController : Controller
    {

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Product/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Product productToCreate)
        {
            // Add product to database
            return RedirectToAction("Index");
        }
    }
}
