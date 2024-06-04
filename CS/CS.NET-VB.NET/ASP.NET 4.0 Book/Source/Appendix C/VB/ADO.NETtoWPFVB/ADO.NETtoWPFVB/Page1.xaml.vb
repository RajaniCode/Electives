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
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql

Namespace ADO.NETtoWPFVB
    ''' <summary>
    ''' Interaction logic for Page1.xaml
    ''' </summary>
    Partial Public Class Page1
        Inherits Page
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub button1_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim mycon As New SqlConnection()
            Dim myadapter As New SqlDataAdapter()
            Dim cmd As New SqlCommand()
            Dim dataquery As [String] = "SELECT EmployeeID, FirstName, LastName,  City, Country FROM Employees"
            cmd.CommandText = dataquery
            myadapter.SelectCommand = cmd
            mycon.ConnectionString = "Data Source=ANAMIKA-PC\SQLEXPRESS;Initial Catalog=northwind;Integrated Security=True"
            cmd.Connection = mycon
            Dim ds As New DataSet()
            myadapter.Fill(ds)
            ListViewEmployeeDetails.DataContext = ds.Tables(0).DefaultView
            mycon.Close()
        End Sub
    End Class
End Namespace

