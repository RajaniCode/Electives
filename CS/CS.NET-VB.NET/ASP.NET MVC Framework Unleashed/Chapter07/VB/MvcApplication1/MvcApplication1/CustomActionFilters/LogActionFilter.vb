Public Class LogAttribute
    Inherits ActionFilterAttribute

    Public Overrides Sub OnActionExecuting(ByVal filterContext As ActionExecutingContext)
        Log(filterContext.RouteData, "Action Executing")
    End Sub

    Public Overrides Sub OnActionExecuted(ByVal filterContext As ActionExecutedContext)
        Log(filterContext.RouteData, "Action Executed")
    End Sub

    Public Overrides Sub OnResultExecuting(ByVal filterContext As ResultExecutingContext)
        Log(filterContext.RouteData, "Result Executing")
    End Sub
    Public Overrides Sub OnResultExecuted(ByVal filterContext As ResultExecutedContext)
        Log(filterContext.RouteData, "Result Executed")
    End Sub

    Private Sub Log(ByVal routeData As RouteData, ByVal message As String)
        ' Extract controller and action name from route data
        Dim controllerAndAction = String.Format("{0}.{1}", routeData.Values("controller"), routeData.Values("action"))

        ' format message
        message = String.Format("{0:T}: {1}: {2}", DateTime.Now, controllerAndAction, message)

        ' write to console
        System.Diagnostics.Debug.WriteLine(message)
    End Sub

End Class