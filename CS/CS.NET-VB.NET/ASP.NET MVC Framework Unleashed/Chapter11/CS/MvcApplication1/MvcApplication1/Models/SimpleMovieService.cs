using System.Collections.Generic;
using System.Web;
using MvcFakes;

namespace MvcApplication1.Models
{
    public class SimpleMovieService : ISimpleMovieService
    {
        private ISimpleMovieRepository _repository;
        private ICache _cache;

        public SimpleMovieService()
            : this(new SimpleMovieRepository(), new CacheWrapper(HttpContext.Current.Cache)) {}

        public SimpleMovieService(ISimpleMovieRepository repository, ICache cache)
        {
            _repository = repository;
            _cache = cache;
        }


        public IEnumerable<Movie> ListMoviesCached()
        {
            var movies = (IEnumerable<Movie>)_cache["movies"];
            if (movies == null)
            {
                movies = ListMovies();
                _cache["movies"] = movies;
            }
            return movies;
        }


        public IEnumerable<Movie> ListMovies()
        {
            return _repository.ListMovies();
        }

    }
}
