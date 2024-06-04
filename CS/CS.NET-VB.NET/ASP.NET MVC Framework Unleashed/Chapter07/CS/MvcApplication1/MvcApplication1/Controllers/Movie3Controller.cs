using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class Movie3Controller : Controller
    {
        // GET: /Movie3/Create
        [ActionName("Create")]
        public ActionResult Create_GET()
        {
            return View();
        } 

        // POST: /Movie3/Create
        [AcceptVerbs(HttpVerbs.Post)]
        [ActionName("Create")]
        public ActionResult Create_POST()
        {
            var movieToCreate = new Movie();
            this.UpdateModel(movieToCreate, new string[] {"Title", "Director", "DateReleased"});
            // Add movie to database
            return RedirectToAction("Index");
        }

    }
}
