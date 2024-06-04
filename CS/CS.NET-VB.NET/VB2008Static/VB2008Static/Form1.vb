Public Class Form1
    'Private Shared Sub subButton1()
    '    Static i As Integer = 0
    '    MessageBox.Show(i.ToString)
    '    i += 1
    'End Sub

    'Private Shared Sub subButton2()
    '    Dim i As Integer = 0
    '    MessageBox.Show(i.ToString)
    '    i += 1
    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Static i As Integer = 0
        MessageBox.Show(i.ToString)
        i += 1
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim i As Integer = 0
        MessageBox.Show(i.ToString)
        i += 1
    End Sub

End Class
