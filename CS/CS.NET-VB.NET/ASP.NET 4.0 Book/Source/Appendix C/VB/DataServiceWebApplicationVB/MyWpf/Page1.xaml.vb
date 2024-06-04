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
Imports System.ComponentModel
Imports MyWpf.ServiceReference1
Namespace MyWpf
    ''' <summary>
    ''' Interaction logic for Page1.xaml
    ''' </summary>
    Partial Public Class Page1
        Inherits Page
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim s As DataBindingWebServiceSoapClient = New ServiceReference1.DataBindingWebServiceSoapClient()
            ListViewEmployeeDetails.DataContext = s.GetData()
        End Sub
    End Class
End Namespace

