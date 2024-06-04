
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Submit1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Submit1.ServerClick
        span1.InnerHtml = Text1.Value.ToString
        span2.InnerHtml = Text2.Value.ToString
        span3.InnerHtml = Text3.Value.ToString
    End Sub

End Class
