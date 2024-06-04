using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class MovieController : Controller
    {
        private MoviesDBEntities _entities = new MoviesDBEntities(); 

        // GET: /Movie/

        public ActionResult Index()
        {
            return View(_entities.MovieSet.ToList());
        }

        // GET: /Movie/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: /Movie/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public string Create(Movie movieToCreate)
        {
            try
            {
                _entities.AddToMovieSet(movieToCreate);
                _entities.SaveChanges();
                return "Inserted new movie " + movieToCreate.Title;
            }
            catch
            {
                return "Could not insert movie " + movieToCreate.Title;
            }
        }

    }
}
