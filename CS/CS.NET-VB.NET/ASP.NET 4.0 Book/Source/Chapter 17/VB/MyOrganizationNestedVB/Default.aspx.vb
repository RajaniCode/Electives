
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Label1.Text = "You have entered " & TextBox1.Text
        Label1.Visible = True

    End Sub

  
End Class
