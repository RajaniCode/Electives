Public Class DownlevelController
    Inherits Controller

    Private _entities As New GuestBookDBEntities()


    Public Function Index() As ActionResult
        Return View(_entities.GuestSet.ToList())
    End Function


    Public Function Create(<Bind(Exclude:="Id")> ByVal guestToCreate As Guest) As ActionResult
        ' validation
        If guestToCreate.Name.Trim().Length = 0 Then
            ModelState.AddModelError("Name", "Name is required.")
        End If
        If guestToCreate.Message.Trim().Length = 0 Then
            ModelState.AddModelError("Message", "Message is required.")
        End If

        If ModelState.IsValid Then
            _entities.AddToGuestSet(guestToCreate)
            _entities.SaveChanges()
        End If

        If Request.IsAjaxRequest() Then
            Return PartialView("GuestBook", _entities.GuestSet.ToList())
        End If

        Return View("Index", _entities.GuestSet.ToList())
    End Function

End Class
