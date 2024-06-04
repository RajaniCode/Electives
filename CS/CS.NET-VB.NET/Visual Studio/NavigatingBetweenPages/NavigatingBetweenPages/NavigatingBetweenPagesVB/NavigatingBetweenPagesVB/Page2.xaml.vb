Partial Public Class Page2
    Inherits UserControl

    Private app As App = Nothing

    Public Sub New 
        InitializeComponent()
        app = CType(Application.Current, App)
        lblDisplay.Text = lblDisplay.Text & " " & app.UserName
    End Sub

    Private Sub btnPage1Go_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        app.GoToPage(New Page1())
    End Sub

End Class
