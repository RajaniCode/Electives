Public Class PersonController
    Inherits System.Web.Mvc.Controller


    Function Index() As ActionResult
        Return View("Index")
    End Function

    Function Details(ByVal id As Integer?) As ActionResult
        If Not id.HasValue Then
            Return RedirectToAction("Index")
        End If

        Return View("Details")
    End Function

End Class
