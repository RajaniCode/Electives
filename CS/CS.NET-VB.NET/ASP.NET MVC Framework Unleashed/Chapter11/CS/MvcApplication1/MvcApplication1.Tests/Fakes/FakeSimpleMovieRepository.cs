using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcApplication1.Models;

namespace MvcApplication1.Tests.Fakes
{
    public class FakeSimpleMovieRepository : ISimpleMovieRepository
    {
        #region ISimpleMovieRepository Members

        public IEnumerable<Movie> ListMovies()
        {
            var movies = new List<Movie>();
            movies.Add(Movie.CreateMovie(1, "Star Wars", "Lucas", DateTime.Parse("1/1/1977")));
            movies.Add(Movie.CreateMovie(2, "King Kong", "Jackson", DateTime.Parse("1/1/2002")));
            movies.Add(Movie.CreateMovie(3, "Memento", "Nolan", DateTime.Parse("1/1/2005")));

            return movies;
        }

        #endregion
    }
}
