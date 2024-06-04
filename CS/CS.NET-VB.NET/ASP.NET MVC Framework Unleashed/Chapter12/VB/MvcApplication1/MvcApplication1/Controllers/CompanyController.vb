Public Class CompanyController
    Inherits Controller

    <Authorize()> _
    Public Function Secrets() As ActionResult
        Return View()
    End Function

    <Authorize(Users:="Jack,Jill")> _
    Public Function SuperSecrets() As ActionResult
        Return View()
    End Function

    <Authorize(Roles:="Manager")> _
    Public Function SuperSuperSecrets() As ActionResult
        Return View()
    End Function

End Class
