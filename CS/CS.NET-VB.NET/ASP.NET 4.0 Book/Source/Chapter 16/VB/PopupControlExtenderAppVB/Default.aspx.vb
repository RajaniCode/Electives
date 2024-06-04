Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.Text = "South Delhi" Then
            Me.TextBox2.Text = "South Delhi"
        ElseIf RadioButtonList1.Text = "North Delhi" Then
            Me.TextBox2.Text = "North Delhi"
        ElseIf RadioButtonList1.Text = "East Delhi" Then
            Me.TextBox2.Text = "East Delhi"
        ElseIf RadioButtonList1.Text = "West Delhi" Then
            Me.TextBox2.Text = "West Delhi"
        ElseIf RadioButtonList1.Text = "Central Delhi" Then
            Me.TextBox2.Text = "Central Delhi"
        End If

    End Sub
End Class
