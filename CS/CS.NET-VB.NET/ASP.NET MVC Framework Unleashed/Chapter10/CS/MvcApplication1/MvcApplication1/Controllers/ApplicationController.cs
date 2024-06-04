using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public abstract class ApplicationController : Controller
    {
        private MoviesDBEntities _entities = new MoviesDBEntities(); 

        public ApplicationController()
        {
            ViewData["categories"] = _entities.MovieCategorySet.ToList();
        }

    }
}
