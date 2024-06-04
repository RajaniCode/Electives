Public Class Form1

    Private F2 As Form2

    ' internal event CustomEventHandler Form1TextBoxEvent;
    Private Event Form1TextBoxEvent As CustomEventHandler


    Private Sub Form2_Form2TextBoxText(ByVal sender As System.Object, ByVal e As CustomEventArgs)

        TextBox1.Text = e.TextBoxTextChanged

    End Sub

    Private Sub OnForm1TextBoxEvent(ByVal e As CustomEventArgs)

        Try
            RaiseEvent Form1TextBoxEvent(Me, e)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        F2 = New Form2()

        ' Form1TextBoxEvent += F2.Form1_Form1TextBoxEvent;
        AddHandler Form1TextBoxEvent, AddressOf F2.Form1_Form1TextBoxEvent

        Dim Form1TextBoxEventArgs As New CustomEventArgs(TextBox1.Text)
        OnForm1TextBoxEvent(Form1TextBoxEventArgs)

        ' F2.Form2TextBoxEvent += Form2_Form2TextBoxText;
        AddHandler F2.Form2TextBoxEvent, AddressOf Form2_Form2TextBoxText

        F2.ShowInTaskbar = False
        F2.ShowDialog()

    End Sub

End Class
