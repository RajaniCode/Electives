Public Class SimpleViewEngine
	Inherits VirtualPathProviderViewEngine

	Public Sub New()
		Me.ViewLocationFormats = New String() { "~/Views/{1}/{0}.simple", "~/Views/Shared/{0}.simple"}
		Me.PartialViewLocationFormats = New String() { "~/Views/{1}/{0}.simple", "~/Views/Shared/{0}.simple" }
	End Sub

	Protected Overrides Function CreateView(ByVal controllerContext As ControllerContext, ByVal viewPath As String, ByVal masterPath As String) As IView
		Dim physicalPath = controllerContext.HttpContext.Server.MapPath(viewPath)
		Return New SimpleView(physicalPath)
	End Function

	Protected Overrides Function CreatePartialView(ByVal controllerContext As ControllerContext, ByVal partialPath As String) As IView
		Dim physicalPath = controllerContext.HttpContext.Server.MapPath(partialPath)
		Return New SimpleView(physicalPath)
	End Function
End Class
