Public Class WidgetController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function


    Function Details(ByVal id As Integer?) As ActionResult
        If Not id.HasValue Then
            Return RedirectToAction("Index")
        End If

        Return View()
    End Function


End Class
