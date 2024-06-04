Public Class NewsController
    Inherits System.Web.Mvc.Controller

    Private ReadOnly _news As New List(Of String)
    Private _rnd As New Random()

    Sub New()
        _news.Add("Moon explodes!")
        _news.Add("Stock market up 200 percent!")
        _news.Add("Talking robot created!")
    End Sub

    Function Index() As ActionResult
        Dim selectedIndex = _rnd.Next(_news.Count)
        ViewData.Model = _news(selectedIndex)
        Return View()
    End Function


    <AjaxMethod()> _
    <ActionName("Index")> _
    Function Index_AJAX() As String
        Dim selectedIndex = _rnd.Next(_news.Count)
        Return _news(selectedIndex)
    End Function


End Class
