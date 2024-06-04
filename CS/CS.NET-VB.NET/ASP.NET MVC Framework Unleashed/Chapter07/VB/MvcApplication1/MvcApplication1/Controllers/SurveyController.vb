Public Class SurveyController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /Survey/Create

    Function Create() As ActionResult
        Return View()
    End Function


    ' POST: /Survey/Create
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal source As List(Of String)) As ActionResult
        Return View()
    End Function

End Class
