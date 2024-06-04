Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc

<TestClass()> _
Public Class HomeControllerTest
    <TestMethod()> _
    Public Sub Index()
        ' Arrange
        Dim controller = New HomeController()

        ' Act
        Dim result = controller.Index()

        ' Did we get a view result?
        Assert.IsInstanceOfType(result, GetType(ViewResult))

        ' Did we get a view named Index?
        Dim indexResult = CType(result, ViewResult)
        Assert.AreEqual("Index", indexResult.ViewName)

        ' Did we get message in view data?
        Assert.AreEqual("Hello World!", indexResult.ViewData("message"))
    End Sub

End Class
