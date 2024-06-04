Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc

<TestClass()> Public Class PersonControllerTest

    <TestMethod()> _
    Public Sub DetailsWithId()
        ' Arrange
        Dim controller As New PersonController()

        ' Act
        Dim result As ViewResult = controller.Details(33)

        ' Assert
        Assert.AreEqual("Details", result.ViewName)
    End Sub

    <TestMethod()> _
    Public Sub DetailsWithoutId()
        ' Arrange
        Dim controller As New PersonController()

        ' Act
        Dim result As RedirectToRouteResult = controller.Details(Nothing)

        ' Assert
        Assert.AreEqual("Index", result.RouteValues("action"))
    End Sub

End Class
