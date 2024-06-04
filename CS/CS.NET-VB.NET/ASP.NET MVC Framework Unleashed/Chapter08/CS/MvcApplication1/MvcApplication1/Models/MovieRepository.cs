using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class MovieRepository : IMovieRepository
    {
        private MoviesDBEntities _entities = new MoviesDBEntities();

        public IEnumerable<Movie> ListMovies()
        {
            return _entities.MovieSet.ToList();
        }

        public void CreateMovie(Movie movieToCreate)
        {
            _entities.AddToMovieSet(movieToCreate);
            _entities.SaveChanges();
        }
    }

    public interface IMovieRepository
    {
        IEnumerable<Movie> ListMovies();
        void CreateMovie(Movie movieToCreate);
    }
}
