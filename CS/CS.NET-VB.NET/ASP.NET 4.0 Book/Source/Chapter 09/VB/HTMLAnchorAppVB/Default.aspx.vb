Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub HTMLAnchor1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles HTMLAnchor1.ServerClick
        span1.InnerHtml = "  You have clicked the HTML Anchor !"
    End Sub
End Class
