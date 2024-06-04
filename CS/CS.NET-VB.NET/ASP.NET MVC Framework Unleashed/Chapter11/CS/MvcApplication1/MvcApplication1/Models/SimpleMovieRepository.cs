using System.Collections.Generic;
using System.Linq;

namespace MvcApplication1.Models
{
    public class SimpleMovieRepository : ISimpleMovieRepository
    {
        private MoviesDBEntities _entities = new MoviesDBEntities();

        public IEnumerable<Movie> ListMovies()
        {
            return _entities.MovieSet.ToList();
        }

    }
}
