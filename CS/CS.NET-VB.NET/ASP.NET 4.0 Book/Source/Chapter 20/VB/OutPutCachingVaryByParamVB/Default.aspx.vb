
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Name.Visible = False
            Label1.Visible = False
            Button1.Visible = False
            Label2.Visible = True
            Label2.Text = "This Output of this page was cached for " & Name.Text & ". The Current time is " & DateTime.Now.ToString()
        End If

    End Sub
End Class
