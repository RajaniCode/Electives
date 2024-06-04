using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class MovieController : Controller
    {
        private MoviesDBEntities _entities = new MoviesDBEntities();

        //
        // GET: /Movie/

        public ActionResult Index()
        {
            return View(_entities.MovieSet.ToList());
        }

        //
        // GET: /Movie/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Movie/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude="Id")]Movie movieToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            // Add movie to database
            return RedirectToAction("Index");
        }


    }
}
