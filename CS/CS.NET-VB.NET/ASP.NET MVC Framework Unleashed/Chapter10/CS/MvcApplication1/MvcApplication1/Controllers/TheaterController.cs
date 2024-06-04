using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class TheaterController : Controller
    {
        private MoviesDBEntities _entities = new MoviesDBEntities();

        public ActionResult Index()
        {
            return View(_entities.MovieSet.ToList());
        }

    }
}
