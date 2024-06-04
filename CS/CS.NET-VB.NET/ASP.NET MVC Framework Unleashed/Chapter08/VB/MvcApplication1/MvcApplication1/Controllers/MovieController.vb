Public Class MovieController
    Inherits Controller

    Private _entities As New MoviesDBEntities()

    Public Function Index() As ActionResult
        Return View(_entities.MovieSet.ToList())
    End Function


    '
    ' GET: /Movie/Create

    Public Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Movie/Create

    <AcceptVerbs(HttpVerbs.Post)> _
    Public Function Create(<Bind(Exclude:="Id")> ByVal movieToCreate As Movie) As ActionResult
        ' Validate
        If movieToCreate.Title.Trim().Length = 0 Then
            ModelState.AddModelError("Title", "Title is required.")
        End If
        If movieToCreate.Title.IndexOf("r") > 0 Then
            ModelState.AddModelError("Title", "Title cannot contain the letter r.")
        End If
        If movieToCreate.Director.Trim().Length = 0 Then
            ModelState.AddModelError("Director", "Director is required.")
        End If
        If (Not ModelState.IsValid) Then
            Return View()
        End If

        ' Add to database
        _entities.AddToMovieSet(movieToCreate)
        _entities.SaveChanges()

        ' Redirect
        Return RedirectToAction("Index")
    End Function


End Class
