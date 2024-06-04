using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;
using MvcApplication1.CutomActionFilters;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        private MoviesDBEntities _entities = new MoviesDBEntities();

        public ActionResult Index()
        {
            var movies = _entities.MovieSet.ToList();
            return View("Index", movies);
        }

        [OutputCache(Duration = 15, VaryByParam = "None")]
        public ActionResult IndexCached()
        {
            var movies = _entities.MovieSet.ToList();
            return View("Index", movies);
        }

    }
}
