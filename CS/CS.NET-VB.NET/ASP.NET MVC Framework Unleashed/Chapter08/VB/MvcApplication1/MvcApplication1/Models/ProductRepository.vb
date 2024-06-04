Public Class ProductRepository
    Implements IProductRepository

    Private _entities As New ProductsDBEntities()

    Public Function ListProducts() As IEnumerable(Of Product) Implements IProductRepository.ListProducts
        Return _entities.ProductSet.ToList()
    End Function

    Public Sub CreateProduct(ByVal productToCreate As Product) Implements IProductRepository.CreateProduct
        _entities.AddToProductSet(productToCreate)
        _entities.SaveChanges()
    End Sub

End Class

Public Interface IProductRepository
    Function ListProducts() As IEnumerable(Of Product)
    Sub CreateProduct(ByVal productToCreate As Product)
End Interface
