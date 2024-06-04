Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Image1_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Image1.ServerClick
        span1.InnerHtml = "You have clicked submit button."
    End Sub
    Protected Sub Image2_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Image2.ServerClick
        span1.InnerHtml = "You have clicked reset button."
    End Sub
End Class
