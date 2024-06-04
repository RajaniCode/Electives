using System.Collections.Generic;
using MvcApplication1.Models;

namespace MvcApplication1.Tests.Models
{
    public class FakeMovieRepository : IMovieRepository
    {
        #region IMovieRepository Members

        public IEnumerable<Movie> ListMovies()
        {
            return null;
        }

        public void CreateMovie(Movie movieToCreate)
        {
        }

        #endregion
    }
}
