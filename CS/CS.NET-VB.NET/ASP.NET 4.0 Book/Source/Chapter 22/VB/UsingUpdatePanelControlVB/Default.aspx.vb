
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ts As New WebService
        Label1.Text = ts.GetServerTime().ToString()
        Label2.Text = ts.GetServerTime().ToString()

    End Sub
End Class
