
Partial Public Class MainPage
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim sc As ServiceReference1.MyServiceClient = New DataBindinginSilverlightVB.ServiceReference1.MyServiceClient
        AddHandler sc.GetByLastNameCompleted, AddressOf sc_GetByLastNameCompleted
        sc.GetByLastNameAsync(DataEntry.Text)
    End Sub
    Private Sub sc_GetByLastNameCompleted(ByVal sender As Object, ByVal e As DataBindinginSilverlightVB.ServiceReference1.GetByLastNameCompletedEventArgs)
        DataGrid.ItemsSource = e.Result
    End Sub

End Class