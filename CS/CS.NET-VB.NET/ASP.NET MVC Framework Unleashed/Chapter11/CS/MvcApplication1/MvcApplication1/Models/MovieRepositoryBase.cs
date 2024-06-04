using System.Collections.Generic;

namespace MvcApplication1.Models
{
    public abstract class MovieRepositoryBase
    {
        public abstract IEnumerable<Movie> ListMoviesCached();
        public abstract IEnumerable<Movie> ListMovies();
        public abstract void CreateMovie(Movie movieToCreate);
    }
}
