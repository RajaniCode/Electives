Public Class MovieController
    Inherits Controller

    Private _entities As New MoviesDBEntities()

    Public Function Index() As ActionResult
        Return View()
    End Function

    Public Function Refresh() As ActionResult
        Return Json(GetThreeMovies())
    End Function


    Private Function GetThreeMovies() As IEnumerable
        Dim rnd = New Random()
        Dim allMovies = _entities.MovieSet.ToList()
        Dim selectedMovies = New List(Of Movie)()

        For i As Integer = 0 To 2
            Dim selected = allMovies(rnd.Next(allMovies.Count))
            allMovies.Remove(selected)
            selectedMovies.Add(selected)
        Next i

        Dim results = From m In selectedMovies _
                      Select New With {Key .Title = m.Title, Key .Director = m.Director}

        Return results
    End Function

End Class
