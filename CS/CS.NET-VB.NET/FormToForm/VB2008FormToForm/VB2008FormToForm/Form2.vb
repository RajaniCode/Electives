Public Class Form2

    ' internal event CustomEventHandler Form2TextBoxEvent;
    Friend Event Form2TextBoxEvent As CustomEventHandler

    Friend Sub Form1_Form1TextBoxEvent(ByVal sender As System.Object, ByVal e As CustomEventArgs)

        TextBox1.Text = e.TextBoxTextChanged

    End Sub

    Private Sub OnForm2TextBoxEvent(ByVal e As CustomEventArgs)

        Try
            RaiseEvent Form2TextBoxEvent(Me, e)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        Dim Form2TextBoxEventArgs As New CustomEventArgs(TextBox1.Text)
        OnForm2TextBoxEvent(Form2TextBoxEventArgs)

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        If (Asc(e.KeyChar) = 13) Then
            Me.Close()
        End If

    End Sub

End Class