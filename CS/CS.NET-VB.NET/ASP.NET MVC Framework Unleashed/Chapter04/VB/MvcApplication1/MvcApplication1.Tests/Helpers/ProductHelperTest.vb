Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MvcFakes

<TestClass()> _
Public Class ProductHelperTest
    <TestMethod()> _
    Public Sub ContainsHtmlRow()
        ' Arrange products
        Dim products = New List(Of Product)()
        products.Add(Product.CreateProduct(-1, "Laptop", "A laptop", 878.23D))
        products.Add(Product.CreateProduct(-1, "Telescope", "A telescape", 200.19D))

        ' Arrange HTML helper
        Dim helper = New FakeHtmlHelper()
        helper.ViewData.Model = products

        ' Act
        Dim result = ProductHelper.ProductList(helper)

        ' Assert
        StringAssert.Contains(result, "<td>Laptop</td><td>$878.23</td>")
    End Sub
End Class
