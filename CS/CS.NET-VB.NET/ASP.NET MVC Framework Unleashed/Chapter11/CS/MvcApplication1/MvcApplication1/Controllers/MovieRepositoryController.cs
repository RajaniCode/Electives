using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class MovieRepositoryController : Controller
    {

        private MovieRepositoryBase _repository;

        public MovieRepositoryController() 
            : this(new MovieRepository()) { }

        public MovieRepositoryController(MovieRepositoryBase repository)
        {
            _repository = repository;
        }


        public ActionResult Index()
        {
            return View(_repository.ListMoviesCached());
        }


        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude="Id")]Movie movieToCreate)
        {
            if (!ModelState.IsValid)
                return View();
            _repository.CreateMovie(movieToCreate);
            return RedirectToAction("Index");
        }


    }
}
