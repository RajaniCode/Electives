<%@ WebHandler Language="VB" Class="GenericHandler" %>

Imports System
Imports System.Web

Public Class GenericHandler : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        ManageForm(context)
    End Sub
 
   Public Sub ManageForm(ByVal context As HttpContext)
		context.Response.Write("<html><body><form>")
		If context.Request.Params("Feature") Is Nothing Then
		context.Response.Write("<h2>Hello there. Select your Favorite Feature of ASP .NET 4.0 </h2>")
		context.Response.Write("<select name='Feature'>")
		context.Response.Write("<option> ASP.NET AJAX</option>")
		context.Response.Write("<option> LINQ </option>")
		context.Response.Write("<option> Silverlight </option>")
		context.Response.Write("<option> WCF </option>")
		context.Response.Write("</select>")
		context.Response.Write("<input type=submit name='Lookup' value='Lookup'></input>")
		context.Response.Write("</br>")
		End If
		If context.Request.Params("Feature") IsNot Nothing Then
			context.Response.Write("Hi, you picked: ")
			context.Response.Write(context.Request.Params("Feature"))
			context.Response.Write(" as your favorite feature.</br>")
		End If
		context.Response.Write("</form></body></html>")
	End Sub

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class