using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class Movie2Controller : Controller
    {
        private IMovieService _service;


        public Movie2Controller() 
        {
            _service = new MovieService(this.ModelState);
        }

        public Movie2Controller(IMovieService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View(_service.ListMovies());
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
        public ActionResult Create([Bind(Exclude = "Id")]Movie movieToCreate)
        {
            if (_service.CreateMovie(movieToCreate))
                return RedirectToAction("Index");
            return View();
        }


    }
}
