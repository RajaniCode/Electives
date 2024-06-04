<%@ WebHandler Language="VB" Class="DisplayImageVB" %>

Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient


Public Class DisplayImageVB : Implements IHttpHandler
    
    Private empPic() As Byte = Nothing
    Private seq As Long = 0

    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim empno As Int32

        If context.Request.QueryString("id") IsNot Nothing Then
            empno = Convert.ToInt32(context.Request.QueryString("id"))
        Else
            Throw New ArgumentException("No parameter specified")
        End If

        context.Response.OutputStream.Write(ShowEmpImage(empno), 78, Convert.ToInt32(seq) - 78)
    End Sub

    Public Function ShowEmpImage(ByVal empno As Integer) As Byte()
        Dim conn As String = ConfigurationManager.ConnectionStrings("NorthwindConnectionString").ConnectionString
        Dim connection As New SqlConnection(conn)
        Dim sql As String = "SELECT photo FROM Employees WHERE EmployeeID = @ID"
        Dim cmd As New SqlCommand(sql, connection)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.AddWithValue("@ID", empno)
        connection.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        If dr.Read() Then
            seq = dr.GetBytes(0, 0, Nothing, 0, Integer.MaxValue) - 1
            empPic = New Byte(seq) {}
            dr.GetBytes(0, 0, empPic, 0, Convert.ToInt32(seq))
            connection.Close()
        End If

        Return empPic
    End Function

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property


End Class