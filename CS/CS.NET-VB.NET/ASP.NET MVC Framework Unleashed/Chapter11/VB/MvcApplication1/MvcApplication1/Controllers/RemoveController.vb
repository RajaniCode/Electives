Public Class RemoveController
    Inherits Controller

    <OutputCache(Duration:=9999, VaryByParam:="None", Location:=OutputCacheLocation.Server)> _
    Public Function Time() As ActionResult
        Return View()
    End Function

    Public Function Clear() As ActionResult
        HttpResponse.RemoveOutputCacheItem("/Remove/Time")
        Return RedirectToAction("Time")
    End Function

End Class
