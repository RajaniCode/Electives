using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class Movie2Controller : Controller
    {
        // GET: /Movie2/Create
        public ActionResult Create()
        {
            return View();
        } 

        // POST: /Movie2/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            var movieToCreate = new Movie();
            this.UpdateModel(movieToCreate, collection.ToValueProvider());
            // Insert movie into database
            return RedirectToAction("Index");
        }
    }
}
