Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class TypeSharingWebService2VB
     Inherits System.Web.Services.WebService


    'Public Function HelloWorld() As String
    '    Return "Hello World"
    'End Function

    Public Class EmpDetails
        Public EmpFirstName As String
        Public EmpMiddleName As String
        Public EmpLastName As String
        Public EmpID As String
        Public EmpDesignation As String
    End Class
    <WebMethod()> _
    Public Function UpdateEmpDetail(ByVal EmpDetail As EmpDetails, ByVal EmpID As String, ByVal EmpDesignation As String) As EmpDetails
        EmpDetail.EmpID = EmpID
        EmpDetail.EmpDesignation = EmpDesignation
        Return EmpDetail
    End Function
End Class