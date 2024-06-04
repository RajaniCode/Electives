Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace BindingtoCLRObjectVB
    ''' <summary>
    ''' Interaction logic for Page1.xaml
    ''' </summary>
    Partial Public Class Page1
        Inherits Page
        Private name1 As New BindingtoCLRObject.Data()
        Public Sub New()
            InitializeComponent()
            nameGrid.DataContext = name1
        End Sub
        Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim message As String = name1.EmployeeID
            Dim caption As String = name1.Name
            MessageBox.Show(message, caption)
        End Sub
    End Class
End Namespace
