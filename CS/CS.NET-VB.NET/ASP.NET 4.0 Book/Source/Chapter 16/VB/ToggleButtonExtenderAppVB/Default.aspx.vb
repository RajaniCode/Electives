
Partial Class _Default
    Inherits System.Web.UI.Page

   

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If CheckBox1.Checked AndAlso CheckBox2.Checked Then
            Label3.Text = "You are a post graduate and also appearing for PHD"
        ElseIf CheckBox1.Checked AndAlso Not CheckBox2.Checked Then
            Label3.Text = "You are a post graduate"
        ElseIf CheckBox2.Checked AndAlso Not CheckBox1.Checked Then
            Label3.Text = "You are appearing for PHD"
        Else
            Label3.Text = "You are neither a post graduate and nor appearing for PHD"
        End If

    End Sub
End Class
