Public Class NotEqual
    Implements IRouteConstraint

    Private _value As String

    Sub New(ByVal value As String)
        _value = value
    End Sub

    Public Function Match( _
        ByVal httpContext As HttpContextBase, _
        ByVal route As Route, _
        ByVal parameterName As String, _
        ByVal values As RouteValueDictionary, _
        ByVal routeDirection As RouteDirection _
    ) As Boolean Implements IRouteConstraint.Match
        Dim paramValue = values(parameterName).ToString()
        Return String.Compare(paramValue, _value, True) <> 0
    End Function

End Class
