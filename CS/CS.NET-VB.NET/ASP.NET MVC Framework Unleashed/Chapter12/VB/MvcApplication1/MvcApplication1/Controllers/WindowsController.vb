Public Class WindowsController
    Inherits Controller

    <Authorize(Users:="redmond\swalther")> _
    Public Function Index() As ActionResult
        ViewData("userName") = User.Identity.Name
        Return View()
    End Function

    <Authorize(Roles:="Managers")> _
    Public Function SalesFigures() As ActionResult
        ViewData("userName") = User.Identity.Name
        Return View()
    End Function

    Public Function SecretStuff() As ActionResult
        If User.IsInRole("Managers") Then
            Return View()
        End If

        Return New HttpUnauthorizedResult()
    End Function

End Class
