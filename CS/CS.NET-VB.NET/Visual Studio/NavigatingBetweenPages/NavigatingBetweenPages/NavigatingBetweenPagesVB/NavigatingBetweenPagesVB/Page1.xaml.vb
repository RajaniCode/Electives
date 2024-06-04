Partial Public Class Page1
    Inherits UserControl

    Public Sub New 
        InitializeComponent()
    End Sub

    Private Sub btnPage2Go_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If txtUser.Text <> String.Empty Then
            Dim app As App = CType(Application.Current, App)
            app.UserName = txtUser.Text
            app.GoToPage(New Page2())
        End If
    End Sub


End Class
