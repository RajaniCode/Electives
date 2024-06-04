Imports System.Reflection

Public Class AjaxMethodAttribute
    Inherits ActionMethodSelectorAttribute

    Public Overrides Function IsValidForRequest(ByVal controllerContext As ControllerContext, ByVal methodInfo As MethodInfo) As Boolean
        Return controllerContext.HttpContext.Request.IsAjaxRequest
    End Function

End Class
