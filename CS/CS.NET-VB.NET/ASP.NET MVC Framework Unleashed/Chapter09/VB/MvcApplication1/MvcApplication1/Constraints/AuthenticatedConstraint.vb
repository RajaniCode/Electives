Imports System.Web
Imports System.Web.Routing

Public Class AuthenticatedConstraint
    Implements IRouteConstraint

    Public Function Match _
    ( _
        ByVal httpContext As HttpContextBase, _
        ByVal route As Route, _
        ByVal parameterName As String, _
        ByVal values As RouteValueDictionary, _
        ByVal routeDirection As RouteDirection _
    ) As Boolean Implements IRouteConstraint.Match
        Return HttpContext.Request.IsAuthenticated
    End Function

End Class
