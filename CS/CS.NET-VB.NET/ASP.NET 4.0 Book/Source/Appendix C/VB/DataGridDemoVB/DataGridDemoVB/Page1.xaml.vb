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

Namespace DataGridDemo
    ''' <summary>
    ''' Interaction logic for Page1.xaml
    ''' </summary>
    Partial Public Class Page1
        Inherits Page
        Public Sub New()
            InitializeComponent()
            dataGrid1.Items.Add("Tim")
            dataGrid1.Items.Add("Jack")
            dataGrid1.Columns.Add(New DataGridTextColumn())
            Dim col1 As New DataGridTextColumn()
            dataGrid1.Columns.Add(col1)
            col1.Binding = New Binding(".")
            col1.Header = "Name"
        End Sub
    End Class
End Namespace