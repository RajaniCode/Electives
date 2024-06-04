Imports System.Reflection

Public NotInheritable Class AcceptAjaxAttribute
    Inherits ActionMethodSelectorAttribute

    Public Overrides Function IsValidForRequest(ByVal controllerContext As ControllerContext, ByVal methodInfo As MethodInfo) As Boolean
        If controllerContext Is Nothing Then
            Throw New ArgumentNullException("controllerContext")
        End If
        Return controllerContext.HttpContext.Request.IsAjaxRequest()
    End Function

End Class
