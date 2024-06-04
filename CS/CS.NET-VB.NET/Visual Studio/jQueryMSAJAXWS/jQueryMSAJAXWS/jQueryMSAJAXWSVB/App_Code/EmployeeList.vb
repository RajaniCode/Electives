Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services
Imports System.Data.SqlClient
Imports System.Data

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class EmployeeList
    Inherits System.Web.Services.WebService

    <ScriptMethod(UseHttpGet:=False, ResponseFormat:=ResponseFormat.Json), WebMethod()> _
    Public Function GetEmployees() As List(Of Employee)
        Dim nwConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("NorthwindConnectionString").ConnectionString
        Dim empList = New List(Of Employee)()
        Using conn As New SqlConnection(nwConn)
            Const sql As String = "SELECT TOP 10 FirstName, LastName, Title, BirthDate FROM Employees"
            conn.Open()
            Using cmd As New SqlCommand(sql, conn)
                Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If dr IsNot Nothing Then
                    Do While dr.Read()
                        Dim emp = New Employee With {.FirstName = dr.GetString(0), .LastName = dr.GetString(1), .Title = dr.GetString(2), .BirthDate = dr.GetDateTime(3)}
                        empList.Add(emp)
                    Loop
                End If
                Return empList
            End Using
        End Using
    End Function

End Class

Public Class Employee
    Private privateFirstName As String
    Public Property FirstName() As String
        Get
            Return privateFirstName
        End Get
        Set(ByVal value As String)
            privateFirstName = value
        End Set
    End Property
    Private privateLastName As String
    Public Property LastName() As String
        Get
            Return privateLastName
        End Get
        Set(ByVal value As String)
            privateLastName = value
        End Set
    End Property
    Private privateTitle As String
    Public Property Title() As String
        Get
            Return privateTitle
        End Get
        Set(ByVal value As String)
            privateTitle = value
        End Set
    End Property
    Private privateBirthDate As DateTime
    Public Property BirthDate() As DateTime
        Get
            Return privateBirthDate
        End Get
        Set(ByVal value As DateTime)
            privateBirthDate = value
        End Set
    End Property
End Class
