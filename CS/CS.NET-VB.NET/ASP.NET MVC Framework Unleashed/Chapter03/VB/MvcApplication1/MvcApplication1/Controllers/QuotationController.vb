Public Class QuotationController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function


    Function List() As ActionResult
        Dim quotes As New List(Of String)()
        quotes.Add("Look before you leap")
        quotes.Add("The early bird gets the worm")
        quotes.Add("All hat, no cattle")

        Return Json(quotes)
    End Function


End Class
