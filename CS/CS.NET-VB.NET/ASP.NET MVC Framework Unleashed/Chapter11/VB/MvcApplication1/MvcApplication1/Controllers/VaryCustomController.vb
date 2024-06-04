Public Class VaryCustomController
    Inherits Controller

    <OutputCache(Duration:=9999, VaryByParam:="None", VaryByCustom:="JS")> _
    Public Function Index() As ActionResult
        If Request.Browser.EcmaScriptVersion.Major > 0 Then
            Return View("IndexJS")
        End If

        Return View("Index")

    End Function

End Class
