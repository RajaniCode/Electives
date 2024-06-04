Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient


' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class DataBindingWebService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetData() As DataSet
        Dim sqlConnection1 As New System.Data.SqlClient.SqlConnection()
        sqlConnection1.ConnectionString = "Data Source=ANAMIKA-PC\SQLEXPRESS;Initial Catalog=northwind;Integrated Security=True"
        Dim selectStr As String = "SELECT EmployeeID, FirstName, LastName,  City, Country FROM Employees"
        Dim da As New SqlDataAdapter(selectStr, sqlConnection1)
        Dim ds As New DataSet()
        da.Fill(ds)
        Return (ds)
    End Function
End Class