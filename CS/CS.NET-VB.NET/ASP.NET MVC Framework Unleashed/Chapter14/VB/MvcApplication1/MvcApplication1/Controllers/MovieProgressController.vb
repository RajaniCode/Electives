Imports System.Threading

Public Class MovieProgressController
    Inherits Controller

    Private _entities As New MoviesDBEntities()

    ' GET: /Movie/

    Public Function Index() As ActionResult
        Return View(_entities.MovieSet.ToList())
    End Function

    ' GET: /Movie/Create

    Public Function Create() As ActionResult
        Return View()
    End Function

    ' POST: /Movie/Create

    <AcceptVerbs(HttpVerbs.Post)> _
    Public Function Create(ByVal movieToCreate As Movie) As String
        Thread.Sleep(5 * 1000)

        Try
            _entities.AddToMovieSet(movieToCreate)
            _entities.SaveChanges()
            Return "Inserted new movie " & movieToCreate.Title
        Catch
            Return "Could not insert movie " & movieToCreate.Title
        End Try
    End Function

End Class
