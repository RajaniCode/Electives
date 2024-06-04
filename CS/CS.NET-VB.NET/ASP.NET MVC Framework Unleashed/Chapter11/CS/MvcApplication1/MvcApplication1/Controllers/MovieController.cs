using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class MovieController : Controller
    {
        private MoviesDBEntities _entities = new MoviesDBEntities(); 

        [OutputCache(Duration=9999, VaryByParam="movieId")]
        public ActionResult Details(int movieId)
        {
            var result = (from movie in _entities.MovieSet
                         where movie.Id == movieId
                         select movie).FirstOrDefault();
            return View(result);
        }

    }
}
