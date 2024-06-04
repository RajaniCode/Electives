Public MustInherit Class ApplicationController
    Inherits System.Web.Mvc.Controller

    Private _entities As New MoviesDBEntities()

    Sub New()
        ViewData("categories") = _entities.MovieCategorySet.ToList()
    End Sub

End Class
