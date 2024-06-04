Public Class FormDataGridView

    Dim ResourceForm As New FormResource(Me)

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ResourceForm.ShowDialog()
    End Sub

End Class