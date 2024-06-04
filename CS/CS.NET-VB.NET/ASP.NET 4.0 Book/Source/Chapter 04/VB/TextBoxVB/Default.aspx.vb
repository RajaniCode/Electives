
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Text = "You have clicked the button"
        TextBox4.Text = "This is a multi line textbox. This is a multi line textbox. This is a multi line textbox. This is a multi line textbox. "
        TextBox3.Text = TextBox2.Text

    End Sub
End Class
