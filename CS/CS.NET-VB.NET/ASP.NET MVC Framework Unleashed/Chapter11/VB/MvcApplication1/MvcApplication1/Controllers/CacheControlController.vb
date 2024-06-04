Public Class CacheControlController
    Inherits Controller

    Public Function Index() As String
        Response.Cache.SetCacheability(HttpCacheability.Private)
        Response.Cache.SetMaxAge(TimeSpan.FromSeconds(10))
        Return DateTime.Now.ToString("T") & " <a href='/CacheControl/Index'>link</a>"
    End Function

End Class
