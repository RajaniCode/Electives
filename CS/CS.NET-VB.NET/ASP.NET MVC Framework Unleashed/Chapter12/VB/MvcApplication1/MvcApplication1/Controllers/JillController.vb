Imports System.Security.Principal

Public Class JillController
    Inherits Controller

    Public Function Index(ByVal user As IPrincipal) As ActionResult
        If user.Identity.Name <> "Jill" Then
            Return New HttpUnauthorizedResult()
        End If

        Return View()
    End Function

End Class
