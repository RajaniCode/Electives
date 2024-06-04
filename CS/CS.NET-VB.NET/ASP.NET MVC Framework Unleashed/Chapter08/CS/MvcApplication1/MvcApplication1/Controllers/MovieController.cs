using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class MovieController : Controller
    {
        private MoviesDBEntities _entities = new MoviesDBEntities();

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
            // Validate
            if (movieToCreate.Title.Trim().Length == 0)
                ModelState.AddModelError("Title", "Title is required.");
            if (movieToCreate.Title.IndexOf("r") > 0)
                ModelState.AddModelError("Title", "Title cannot contain the letter r.");
            if (movieToCreate.Director.Trim().Length == 0)
                ModelState.AddModelError("Director", "Director is required.");
            if (!ModelState.IsValid)
                return View();
        
            // Add to database
            _entities.AddToMovieSet(movieToCreate);
            _entities.SaveChanges();

            // Redirect
            return RedirectToAction("Index");
        }


    }
}
