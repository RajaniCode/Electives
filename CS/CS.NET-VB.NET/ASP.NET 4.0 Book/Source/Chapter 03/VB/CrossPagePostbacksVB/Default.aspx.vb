
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label1.Text = "Hi " + TextBox1.Text + ", here is the output of the Same Page Post Back Button: " + Calendar1.SelectedDate.ToString()
    End Sub
End Class
