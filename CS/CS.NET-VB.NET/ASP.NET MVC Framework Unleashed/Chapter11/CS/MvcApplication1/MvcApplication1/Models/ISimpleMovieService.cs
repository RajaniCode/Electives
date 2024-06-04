using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public interface ISimpleMovieService
    {
        IEnumerable<Movie> ListMoviesCached();
    }
}
