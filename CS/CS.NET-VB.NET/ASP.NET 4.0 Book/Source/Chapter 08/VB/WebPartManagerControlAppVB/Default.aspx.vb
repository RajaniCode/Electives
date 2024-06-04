
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Label2.Visible = True
        Button2.Visible = False
        Dim wpm As New WebPartManager
        Dim str As String
        str = wpm.DisplayMode.Name
        Label2.Text = str
        Label1.Visible = True

    End Sub
End Class
