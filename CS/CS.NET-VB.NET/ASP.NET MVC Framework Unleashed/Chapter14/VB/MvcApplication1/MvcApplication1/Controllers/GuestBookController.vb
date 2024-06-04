Public Class GuestBookController
    Inherits Controller

    Private _entities As New GuestBookDBEntities()

    ' GET: /GuestBook/

    Public Function Index() As ActionResult
        Return View(_entities.GuestSet.ToList())
    End Function

    ' POST: /GuestBook/Create

    Public Function Create(ByVal guestToCreate As Guest) As ActionResult
        _entities.AddToGuestSet(guestToCreate)
        _entities.SaveChanges()

        Return PartialView("Guests", _entities.GuestSet.ToList())
    End Function
End Class
