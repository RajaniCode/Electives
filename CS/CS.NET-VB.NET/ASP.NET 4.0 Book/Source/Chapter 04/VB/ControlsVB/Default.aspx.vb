
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label2.Text = ""
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Enabled = Not TextBox1.Enabled
        If TextBox1.Enabled = True Then
            Label2.Text = "TextBox is enabled"
        Else
            Label2.Text = "TextBox is disabled"
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Visible = Not TextBox1.Visible
        If TextBox1.Visible = True Then
            Label2.Text = "TextBox is visible"
        Else
            Label2.Text = "TextBox is hidden"
        End If
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Style("BACKGROUND-COLOR") = "aqua"
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.Text = "CheckBox is selected"
        Else
            TextBox2.Text = "CheckBox is not selected"
        End If
    End Sub
End Class
