Public Class WidgetController
    Inherits System.Web.Mvc.Controller


    ' GET: /Widget/Create
    Function Create() As ActionResult
        Return View()
    End Function


    ' POST: /Widget/Create
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal widgetToCreate As Widget) As ActionResult
        If Not ModelState.IsValid Then
            Return View()
        End If

        ' Add widget to database
        Return RedirectToAction("Index")
    End Function

End Class
