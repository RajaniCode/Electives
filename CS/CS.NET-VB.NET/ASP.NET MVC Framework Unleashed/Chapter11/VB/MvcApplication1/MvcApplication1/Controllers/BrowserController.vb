Public Class BrowserController
    Inherits Controller

    <OutputCache(Duration:=999, VaryByParam:="None", VaryByCustom:="Browser")> _
    Public Function Index() As String
        Return DateTime.Now.ToString("T") & ":" & Request.UserAgent
    End Function

End Class
