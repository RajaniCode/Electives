
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Label4.Text = e.X.ToString() & " , " & e.Y.ToString()
    End Sub
End Class
