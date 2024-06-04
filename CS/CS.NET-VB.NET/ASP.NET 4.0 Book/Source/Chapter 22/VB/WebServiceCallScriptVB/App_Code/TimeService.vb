Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="TimeService")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class TimeService
    Inherits System.Web.Services.WebService

    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '    Return "Hello World"
    'End Function
    <WebMethod()> _
    Public Function ServerTime(ByVal myName As String) As String
        If myName = "" Then
            Throw New Exception("Please Enter Your Name")
        End If
        Return String.Format("Hello {0}, the time on the server is:  {1}", myName, DateTime.Now.ToString())
    End Function

End Class