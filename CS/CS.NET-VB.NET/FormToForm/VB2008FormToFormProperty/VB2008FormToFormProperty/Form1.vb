Public Class Form1

    Friend Property TextBoxText() As String
        Get
            Return textBox1.Text
        End Get
        Set(ByVal Value As String)
            textBox1.Text = value
        End Set
    End Property


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Dim F2 As Form2 = New Form2() 
        Dim F2 As Form2 = New Form2(Me) '

        F2.ShowInTaskbar = False
        F2.ShowDialog()

    End Sub

End Class
