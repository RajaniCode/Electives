Public Class FeaturedProductAttribute
    Inherits ActionFilterAttribute

    Private _entities As New ProductsDBEntities()

    Public Overrides Sub OnResultExecuting(ByVal filterContext As ResultExecutingContext)
        Dim viewData = filterContext.Controller.ViewData
        viewData("featured") = GetRandomProducts()
    End Sub

    Private Function GetRandomProducts() As IList(Of Product)
        Dim rnd = New Random()
        Dim allProducts = _entities.ProductSet.ToList()
        Dim featuredProducts = New List(Of Product)()
        For i As Integer = 0 To 2
            Dim product = allProducts(rnd.Next(allProducts.Count))
            allProducts.Remove(product)
            featuredProducts.Add(product)
        Next
        Return featuredProducts
    End Function

End Class
