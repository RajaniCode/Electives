Public Class DynamicController
    Inherits Controller

    Public Function Index() As ActionResult
        ' Randomly select master page
        Dim rnd = New Random()
        Dim masterPage = "Dynamic" & rnd.Next(2)

        ' Return view with master page
        Return View("Index", masterPage)
    End Function

End Class
