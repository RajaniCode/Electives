using System.Collections.Generic;

namespace MvcApplication1.Models
{
    public interface ISimpleMovieRepository
    {
        IEnumerable<Movie> ListMovies();
    }
}
