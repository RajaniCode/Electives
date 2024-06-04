Public Class MovieController
    Inherits System.Web.Mvc.Controller

    Private _entities As New MoviesDBEntities()

    '
    ' GET: /Movie/

    Function Index() As ActionResult
        Return View(_entities.MovieSet.ToList())
    End Function


    '
    ' GET: /Movie/Create

    Function Create() As ActionResult
        Return View()
    End Function


    ' POST: /Movie/Create
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(<Bind(Exclude:="Id")> ByVal movieToCreate As Movie) As ActionResult
        If Not ModelState.IsValid Then
            Return View()
        End If

        ' Add movie to database
        Return RedirectToAction("Index")
    End Function


End Class
