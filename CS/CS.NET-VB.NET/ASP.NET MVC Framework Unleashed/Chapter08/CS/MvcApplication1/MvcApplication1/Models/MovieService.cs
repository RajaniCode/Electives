using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcApplication1.Models
{
    public class MovieService : IMovieService
    {
        private ModelStateDictionary _modelState;
        private IMovieRepository _repository;

        public MovieService(ModelStateDictionary modelState)
            :this(modelState, new MovieRepository()){}

        public MovieService(ModelStateDictionary modelState, IMovieRepository repository)
        {
            _modelState = modelState;
            _repository = repository;
        }

        public IEnumerable<Movie> ListMovies()
        {
            return _repository.ListMovies();
        }

        public bool CreateMovie(Movie movieToCreate)
        {
            // validate
            if (movieToCreate.Title.Trim().Length == 0)
                _modelState.AddModelError("Title", "Title is required.");
            if (movieToCreate.Title.IndexOf("r") > 0)
                _modelState.AddModelError("Title", "Title cannot contain the letter r.");
            if (movieToCreate.Director.Trim().Length == 0)
                _modelState.AddModelError("Director", "Director is required.");
            if (!_modelState.IsValid)
                return false;

            _repository.CreateMovie(movieToCreate);
            return true;
        }
    }


    public interface IMovieService
    {
        IEnumerable<Movie> ListMovies();
        bool CreateMovie(Movie movieToCreate);
    }
}
