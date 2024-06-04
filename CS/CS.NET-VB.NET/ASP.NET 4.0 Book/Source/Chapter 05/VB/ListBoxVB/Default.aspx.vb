
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As ListItem
        For Each dt In ListBox2.Items
            If dt.Selected = True Then
                ListBox1.Items.Add(dt.Text)
            End If
        Next
    End Sub

End Class
