
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub TimeUpdater_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TimeLabel.Text = System.DateTime.Now.ToLongTimeString
    End Sub
End Class
