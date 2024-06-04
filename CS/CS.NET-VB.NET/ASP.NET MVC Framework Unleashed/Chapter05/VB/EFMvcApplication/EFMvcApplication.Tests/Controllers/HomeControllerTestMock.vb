Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq
Imports System.Web.Mvc
Imports GenericRepository

<TestClass()> _
Public Class HomeControllerTestMock

    Private _mockRepository As Mock(Of IGenericRepository)

    <TestInitialize()> _
    Sub Initialize()
        _mockRepository = New Mock(Of IGenericRepository)()
    End Sub


    <TestMethod()> _
    Sub NameIsRequired()
        ' Arrange
        Dim controller As New HomeController(_mockRepository.Object)
        Dim productToCreate As New Product()
        productToCreate.Name = String.Empty

        ' Act
        Dim result As ViewResult = controller.Create(productToCreate)

        ' Assert
        Dim modelStateError = result.ViewData.ModelState("Name").Errors(0).ErrorMessage
        Assert.AreEqual("Product name is required.", modelStateError)
    End Sub

End Class
