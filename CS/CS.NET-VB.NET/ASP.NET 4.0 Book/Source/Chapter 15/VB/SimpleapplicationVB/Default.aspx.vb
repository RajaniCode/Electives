
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Btndisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btndisplay.Click
        Dim myDateTime As String
        myDateTime = System.DateTime.Today.ToLongDateString() + " "
        myDateTime += System.DateTime.Now.ToLongTimeString()
        TimeLabel.Text = myDateTime

    End Sub
End Class
