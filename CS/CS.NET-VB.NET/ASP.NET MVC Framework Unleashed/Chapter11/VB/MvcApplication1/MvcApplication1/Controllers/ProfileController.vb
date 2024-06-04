Public Class ProfileController
    Inherits Controller

    <OutputCache(CacheProfile:="Profile1")> _
    Public Function Index() As String
        Return DateTime.Now.ToString("T")
    End Function

End Class
