Public Class SimpleController
    Inherits Controller

    <OutputCache(Duration:=5, VaryByParam:="none")> _
    Public Function Time() As String
        Return DateTime.Now.ToString("T")
    End Function

End Class
