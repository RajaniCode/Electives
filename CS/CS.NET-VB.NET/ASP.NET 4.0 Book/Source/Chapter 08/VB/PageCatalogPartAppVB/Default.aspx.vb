
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim wpm1 As New WebPartManager
    Dim pcp As New PageCatalogPart

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label2.Text = pcp.ChromeState.ToString
        Label3.Text = pcp.ChromeType.ToString
        Label4.Text = pcp.Title
        Label6.Text = pcp.EnableViewState

    End Sub
End Class
