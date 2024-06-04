
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub CheckBoxList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxList1.SelectedIndexChanged
        Dim s As String
        s = "<font color=black> Selected Employess:</font><br>"
        For i As Integer = 0 To CheckBoxList1.Items.Count - 1
            If CheckBoxList1.Items(i).Selected Then
                s = s & CheckBoxList1.Items(i).Text & "<br>"
            End If
        Next i
        Label3.Text = s

    End Sub
End Class
