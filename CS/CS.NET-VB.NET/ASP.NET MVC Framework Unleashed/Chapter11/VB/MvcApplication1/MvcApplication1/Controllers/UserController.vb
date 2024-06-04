Public Class UserController
    Inherits Controller

    <OutputCache(Duration:=9999, VaryByParam:="None", Location:=OutputCacheLocation.Client)> _
    Public Function Index() As String
        Return User.Identity.Name
    End Function

End Class
