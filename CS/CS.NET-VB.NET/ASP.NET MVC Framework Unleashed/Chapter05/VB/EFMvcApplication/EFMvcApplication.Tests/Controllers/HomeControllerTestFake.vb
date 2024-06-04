Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports GenericRepository
Imports System.Web.Mvc
Imports System.Collections

<TestClass()> _
Public Class HomeControllerTestFake
    
Private _fakeRepository As IGenericRepository

    <TestInitialize()> _
    Public Sub Initialize()
        _fakeRepository = New FakeGenericRepository()
    End Sub

    <TestMethod()> _
    Public Sub CreateThenList()
        ' Arrange
        Dim controller = New HomeController(_fakeRepository)
        Dim productToCreate = Product.CreateProduct(-1, "Test", "Test", 3.44D)

        ' Act
        controller.Create(productToCreate)
        Dim results = CType(controller.Index(), ViewResult)

        ' Assert
        Dim products = CType(results.ViewData.Model, ICollection)
        CollectionAssert.Contains(products, productToCreate)
    End Sub

End Class
