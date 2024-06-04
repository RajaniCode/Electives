Public Class NewsController
    Inherits Controller

    Public Function Index() As ActionResult
        Return View()
    End Function

    Public Function Refresh() As ActionResult
        Dim newsPartial = ""
        Dim rnd = New Random()
        Select Case rnd.Next(2)
            Case 0
                newsPartial = "News/News1"
            Case 1
                newsPartial = "News/News2"
        End Select

        Return PartialView(newsPartial)
    End Function

End Class
