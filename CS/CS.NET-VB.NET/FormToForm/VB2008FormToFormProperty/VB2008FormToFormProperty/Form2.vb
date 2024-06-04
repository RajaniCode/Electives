Public Class Form2

    Dim F1 As Form1 '

    ' Dim F1 As Form1 = CType(Application.OpenForms("Form1"), Form1) 

    Public Sub New() '

        ' This call is required by the Windows Form Designer.
        InitializeComponent() '

        ' Add any initialization after the InitializeComponent() call.

    End Sub '

    '
    Public Sub New(ByVal F1 As Form1)
        Me.New()
        Me.F1 = F1
    End Sub
    '

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        F1.TextBoxText = TextBox1.Text
        Me.Close()

    End Sub

    Private Sub Form2_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

        TextBox1.Text = F1.TextBoxText
        TextBox1.Focus()

    End Sub

End Class