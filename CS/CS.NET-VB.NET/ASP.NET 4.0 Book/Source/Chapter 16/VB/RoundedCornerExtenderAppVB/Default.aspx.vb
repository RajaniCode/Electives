
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label1.Text = "The Address of " & TextBox1.Text + " is " & TextBox2.Text
    End Sub
End Class
