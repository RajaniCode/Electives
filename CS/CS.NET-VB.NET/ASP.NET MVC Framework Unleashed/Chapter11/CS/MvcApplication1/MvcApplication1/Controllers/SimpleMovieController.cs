using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class SimpleMovieController : Controller
    {
        private ISimpleMovieService _service;

        public SimpleMovieController() 
            : this(new SimpleMovieService()) { }

        public SimpleMovieController(ISimpleMovieService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View(_service.ListMoviesCached());
        }
    }
}
