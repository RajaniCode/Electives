Imports System.Security.Principal

Public Class CompanyController
    Inherits Controller

    Public Function GetSecret(<ModelBinder(GetType(UserModelBinder))> ByVal user As IPrincipal) As String
        If user.Identity.Name = "CEO" Then
            Return "The secret is 42."
        Else
            Return "You are not authorized!"
        End If
    End Function

End Class
