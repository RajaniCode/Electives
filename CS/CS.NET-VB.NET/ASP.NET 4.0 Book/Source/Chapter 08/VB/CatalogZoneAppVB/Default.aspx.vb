
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim wpm As New WebPartManager
        Dim cz As New CatalogZone
        Dim str As String
        cz.EmptyZoneText = "no controls found!!!"
        Label4.Text = cz.EmptyZoneText
        cz.SelectedCatalogPartID = "selected zone.."
        Label6.Text = cz.SelectedCatalogPartID
        str = WebPartManager.CatalogDisplayMode.Name
        Label8.Text = str
        Label4.Visible = True
        Label6.Visible = True
        Label8.Visible = True

    End Sub
End Class
