Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class ClassProduct

    Public Function getinfo() As DataSet

        Dim con As New SqlConnection("Data Source=PUNEET-PC\SQLEXPRESS;Initial Catalog=northwnd;Integrated Security=True")
        Dim da As New SqlDataAdapter("Select * from Products", con)
        Dim ds As New DataSet()
        da.Fill(ds)
        Return ds

    End Function


End Class
