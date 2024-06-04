Imports System.Data.SqlClient

Partial Class _Default
    Inherits System.Web.UI.Page

    <System.Web.Services.WebMethod()> _
    Public Shared Function GetContactName(ByVal custid As String) As String
        If custid Is Nothing OrElse custid.Length = 0 Then
            Return String.Empty
        End If
        Dim conn As SqlConnection = Nothing
        Try
            Dim connection As String = ConfigurationManager.ConnectionStrings("NorthwindConnectionString").ConnectionString
            conn = New SqlConnection(connection)
            Dim sql As String = "Select ContactName from Customers where CustomerId = @CustID"
            Dim cmd As SqlCommand = New SqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("CustID", custid)
            conn.Open()
            Dim contNm As String = Convert.ToString(cmd.ExecuteScalar())
            Return contNm
        Catch ex As SqlException
            Return "error"
        Finally
            conn.Close()
        End Try
    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            txtId1.Attributes.Add("onblur", "javascript:CallMe('" & txtId1.ClientID & "', '" & txtContact1.ClientID & "')")
            txtId2.Attributes.Add("onblur", "javascript:CallMe('" & txtId2.ClientID & "', '" & txtContact2.ClientID & "')")
        End If

    End Sub
End Class