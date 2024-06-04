using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class MovieController : Controller
    {
        MoviesDBEntities _entities = new MoviesDBEntities(); 

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Refresh()
        {
            return Json( GetThreeMovies() );
        }


        private IEnumerable GetThreeMovies()
        {
            var rnd = new Random();
            var allMovies = _entities.MovieSet.ToList();
            var selectedMovies = new List<Movie>();

            for (int i = 0; i < 3; i++)
            {
                var selected = allMovies[rnd.Next(allMovies.Count)];
                allMovies.Remove(selected);
                selectedMovies.Add(selected);
            }

            var results = from m in selectedMovies
                          select new {Title=m.Title, Director=m.Director};

            return results;
        }

    }
}
