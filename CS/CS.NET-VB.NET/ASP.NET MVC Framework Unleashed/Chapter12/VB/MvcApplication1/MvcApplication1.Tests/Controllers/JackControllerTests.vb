Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc

<TestClass()> _
Public Class JackControllerTests

    <TestMethod()> _
    Public Sub JackCanAccessIndex()
        ' Arrange
        Dim controller As New CompanyController()
        Dim indexAction = GetType(JackController).GetMethod("Index")
        Dim authorizeAttributes = indexAction.GetCustomAttributes(GetType(AuthorizeAttribute), True)

        ' Assert
        Assert.IsTrue(authorizeAttributes.Length > 0)
        For Each att As AuthorizeAttribute In authorizeAttributes
            Assert.AreEqual("Jack", att.Users)
        Next att
    End Sub
End Class
