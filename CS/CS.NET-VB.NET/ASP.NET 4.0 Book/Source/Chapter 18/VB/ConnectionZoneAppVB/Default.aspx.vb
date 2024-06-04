
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.WebPartManager1.DisplayMode = WebPartManager.ConnectDisplayMode
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        Me.WebPartManager1.DisplayMode = WebPartManager.BrowseDisplayMode
    End Sub

End Class
