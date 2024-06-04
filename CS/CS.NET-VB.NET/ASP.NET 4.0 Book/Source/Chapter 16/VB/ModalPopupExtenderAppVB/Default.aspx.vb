
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If RadioButton1.Checked Then
            Label4.Text = "You have Selected Football"
        ElseIf RadioButton2.Checked Then
            Label4.Text = "You have Selected Cricket"
        End If
    End Sub
End Class
