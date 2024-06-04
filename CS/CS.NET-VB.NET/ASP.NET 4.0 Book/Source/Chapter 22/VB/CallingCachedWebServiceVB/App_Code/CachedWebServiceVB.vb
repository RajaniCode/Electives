Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class CachedWebServiceVB
     Inherits System.Web.Services.WebService

    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '    Return "Hello World"
    'End Function

    <WebMethod(CacheDuration:=60)> _
    Public Function GetCacheResult(ByVal num1 As Integer, ByVal num2 As Integer) As String
        Return "The result is " & (num1 + num2).ToString() & ", and the cached time is " & System.DateTime.Now.ToString()
    End Function


End Class