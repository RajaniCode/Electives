
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Master.Header = "Header"
        Master.Page.Title = "Content Page"
        Label1.Text = Master.Header

    End Sub
End Class
