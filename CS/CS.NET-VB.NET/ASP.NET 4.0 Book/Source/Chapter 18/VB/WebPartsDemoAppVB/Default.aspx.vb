
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        WebPartManager1.DisplayMode = WebPartManager.BrowseDisplayMode
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        WebPartManager1.DisplayMode = WebPartManager.EditDisplayMode
    End Sub

    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton4.Click
        WebPartManager1.DisplayMode = WebPartManager.CatalogDisplayMode
    End Sub

    Protected Sub LinkButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton5.Click
        WebPartManager1.DisplayMode = WebPartManager.DesignDisplayMode
    End Sub
End Class
