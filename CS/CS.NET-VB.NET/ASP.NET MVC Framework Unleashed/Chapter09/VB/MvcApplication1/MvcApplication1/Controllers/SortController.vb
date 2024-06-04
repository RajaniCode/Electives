Public Class SortController
    Inherits System.Web.Mvc.Controller

    Public Function Index(ByVal values As String) As String
        Dim brokenValues = values.Split("/"c)
        Array.Sort(brokenValues)
        Return String.Join(", ", brokenValues)
    End Function

End Class
