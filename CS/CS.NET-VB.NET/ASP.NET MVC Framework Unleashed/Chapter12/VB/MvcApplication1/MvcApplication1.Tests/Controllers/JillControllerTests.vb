Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc

<TestClass()> _
Public Class JillControllerTests

    <TestMethod()> _
    Public Sub JillCanAccessIndex()
        ' Arrange
        Dim controller = New JillController()
        Dim principal = New FakePrincipal("Jill")

        ' Act
        Dim result = controller.Index(principal)

        ' Assert
        Assert.IsInstanceOfType(result, GetType(ViewResult))
    End Sub

    <TestMethod()> _
    Public Sub JackCannotAccessIndex()
        ' Arrange
        Dim controller = New JillController()
        Dim principal = New FakePrincipal("Jack")

        ' Act
        Dim result = controller.Index(principal)

        ' Assert
        Assert.IsInstanceOfType(result, GetType(HttpUnauthorizedResult))
    End Sub


End Class

