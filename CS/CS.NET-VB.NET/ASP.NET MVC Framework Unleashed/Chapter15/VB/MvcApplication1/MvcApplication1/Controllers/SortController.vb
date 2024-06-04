Public Class SortController
    Inherits System.Web.Mvc.Controller

    Private _entities As New MoviesDBEntities()

    Function Index() As ActionResult
        Return View(_entities.MovieSet.ToList())
    End Function

End Class
