
Partial Class PopupWin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtReverse.Text = Request.QueryString("ControlVal").ToString()
    End Sub
End Class
