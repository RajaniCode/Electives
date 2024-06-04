using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace MvcApplication1.Models
{

    public class MovieRepository : MovieRepositoryBase
    {
        private MoviesDBEntities _entities = new MoviesDBEntities();
        private Cache _cache;

        public MovieRepository()
        {
            _cache = HttpContext.Current.Cache;
        }


        public override IEnumerable<Movie> ListMoviesCached()
        {
            var movies = (IEnumerable<Movie>)_cache["movies"];
            if (movies == null)
            {
                movies = ListMovies();
                _cache["movies"] = movies;
            }
            return movies;
        }


        public override IEnumerable<Movie> ListMovies()
        {
            return _entities.MovieSet.ToList();
        }


        public override void CreateMovie(Movie movieToCreate)
        {
            _entities.AddToMovieSet(movieToCreate);
            _entities.SaveChanges();
            _cache.Remove("movies");
        }
    }
}
