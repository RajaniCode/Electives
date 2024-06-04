Public Class JackController
    Inherits Controller

    <Authorize(Users:="Jack")> _
    Public Function Index() As ActionResult
        Return View()
    End Function

End Class
