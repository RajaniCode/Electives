Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="WebService")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
 Public Class WebService
    Inherits System.Web.Services.WebService

    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '    Return "Hello World"
    'End Function
    <WebMethod()> _
    Public Function Multiply(ByVal num1 As Integer, ByVal num2 As Integer) As String
        Dim multiplyVal As Integer = num1 * num2
        Dim result As String = String.Format("The Multiplication result is {0}.", multiplyVal.ToString())
        Return result
    End Function


End Class