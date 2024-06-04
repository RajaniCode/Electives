Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Routing
Imports MvcFakes
Imports RouteDebugger.Routing

<TestClass()> _
 Public Class RouteTests

    ''' <summary>
    ''' Verifies that the URL ~/ matches the Default route.
    ''' </summary>
    <TestMethod()> _
    Public Sub DefaultRoute()
        ' Arrange
        Dim routes = New RouteCollection()
        MvcApplication.RegisterRoutes(routes)

        ' Act
        Dim context = New FakeHttpContext("~/")
        Dim routeData = routes.GetRouteData(context)

        ' Assert
        Dim matchedRoute = CType(routeData.Route, NamedRoute)
        Assert.AreEqual("Default", matchedRoute.Name)
    End Sub

    ''' <summary>
    ''' Verifies that the URL ~/Archive/2008 matches the ArchiveYear route.
    ''' </summary>
    <TestMethod()> _
    Public Sub ArchiveYear()
        ' Arrange
        Dim routes = New RouteCollection()
        MvcApplication.RegisterRoutes(routes)

        ' Act
        Dim context = New FakeHttpContext("~/Archive/2008")
        Dim routeData = routes.GetRouteData(context)

        ' Assert
        Dim matchedRoute = CType(routeData.Route, NamedRoute)
        Assert.AreEqual("ArchiveYear", matchedRoute.Name)
        Assert.AreEqual("2008", routeData.Values("year"))
    End Sub

    ''' <summary>
    ''' Verifies that the URL ~/Archive/2008/12 matches the ArchiveMonth route.
    ''' </summary>
    <TestMethod()> _
    Public Sub ArchiveYearMonth()
        ' Arrange
        Dim routes = New RouteCollection()
        MvcApplication.RegisterRoutes(routes)

        ' Act
        Dim context = New FakeHttpContext("~/Archive/2008/12")
        Dim routeData = routes.GetRouteData(context)

        ' Assert
        Dim matchedRoute = CType(routeData.Route, NamedRoute)
        Assert.AreEqual("ArchiveYearMonth", matchedRoute.Name)
        Assert.AreEqual("2008", routeData.Values("year"))
        Assert.AreEqual("12", routeData.Values("month"))
    End Sub


    ''' <summary>
    ''' Verifies that the URL ~/Archive/2008/12/25 matches the ArchiveMonthDay route.
    ''' </summary>
    <TestMethod()> _
    Public Sub ArchiveYearMonthDay()
        ' Arrange
        Dim routes = New RouteCollection()
        MvcApplication.RegisterRoutes(routes)

        ' Act
        Dim context = New FakeHttpContext("~/Archive/2008/12/25")
        Dim routeData = routes.GetRouteData(context)

        ' Assert
        Dim matchedRoute = CType(routeData.Route, NamedRoute)
        Assert.AreEqual("ArchiveYearMonthDay", matchedRoute.Name)
        Assert.AreEqual("2008", routeData.Values("year"))
        Assert.AreEqual("12", routeData.Values("month"))
        Assert.AreEqual("25", routeData.Values("day"))
    End Sub


    ''' <summary>
    ''' Verifies that the URL ~/Archive/2008/12/Test matches the Details route.
    ''' </summary>
    <TestMethod()> _
    Public Sub ArchiveYearMonthDayName()
        ' Arrange
        Dim routes = New RouteCollection()
        MvcApplication.RegisterRoutes(routes)

        ' Act
        Dim context = New FakeHttpContext("~/Archive/2008/12/25/Test")
        Dim routeData = routes.GetRouteData(context)

        ' Assert
        Dim matchedRoute = CType(routeData.Route, NamedRoute)
        Assert.AreEqual("Details", matchedRoute.Name)
        Assert.AreEqual("2008", routeData.Values("year"))
        Assert.AreEqual("12", routeData.Values("month"))
        Assert.AreEqual("25", routeData.Values("day"))
        Assert.AreEqual("Test", routeData.Values("name"))
    End Sub



End Class
