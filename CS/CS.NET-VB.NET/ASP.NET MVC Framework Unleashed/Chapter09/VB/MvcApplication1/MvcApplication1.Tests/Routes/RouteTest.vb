Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Routing
Imports MvcFakes
Imports RouteDebugger.Routing

<TestClass()> _
Public Class RouteTest

    <TestMethod()> _
    Public Sub DefaultRouteMatchesHome()
        ' Arrange
        Dim routes = New RouteCollection()
        MvcApplication.RegisterRoutes(routes)

        ' Act
        Dim context = New FakeHttpContext("~/Home")
        Dim routeData = routes.GetRouteData(context)

        ' Assert
        Dim matchedRoute = CType(routeData.Route, NamedRoute)
        Assert.AreEqual("Default", matchedRoute.Name)
    End Sub


    <TestMethod()> _
    Public Sub ProductInsertMatchesPost()
        ' Arrange
        Dim routes = New RouteCollection()
        MvcApplication.RegisterRoutes(routes)

        ' Act
        Dim context = New FakeHttpContext("~/Product/Insert", "POST", False, Nothing)
        Dim routeData = routes.GetRouteData(context)

        ' Assert
        Dim matchedRoute = CType(routeData.Route, NamedRoute)
        Assert.AreEqual("ProductInsert", matchedRoute.Name)
    End Sub




    <TestMethod()> _
    Public Sub ProductInsertDoesNotMatchGet()
        ' Arrange
        Dim routes = New RouteCollection()
        MvcApplication.RegisterRoutes(routes)

        ' Act
        Dim context = New FakeHttpContext("~/Product/Insert", "GET", False, Nothing)
        Dim routeData = routes.GetRouteData(context)

        ' Assert
        If routeData IsNot Nothing Then
            Dim matchedRoute = CType(routeData.Route, NamedRoute)
            Assert.AreNotEqual("ProductInsert", matchedRoute.Name)
        End If
    End Sub



End Class
