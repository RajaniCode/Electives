Public Class ProductRepository
	Implements IProductRepository

	Private _entities As New ProductsDBEntities()

	#Region "IProductRepository Members"

	Public Function List() As IEnumerable(Of Product) Implements IProductRepository.List
		Return _entities.ProductSet.ToList()
	End Function

	Public Function [Get](ByVal id As Integer) As Product Implements IProductRepository.Get
		Return (From p In _entities.ProductSet _
		        Where p.Id = id _
		        Select p).FirstOrDefault()
	End Function

	Public Sub Create(ByVal productToCreate As Product) Implements IProductRepository.Create
		_entities.AddToProductSet(productToCreate)
		_entities.SaveChanges()
	End Sub

	Public Sub Edit(ByVal productToEdit As Product) Implements IProductRepository.Edit
		Dim originalProduct = [Get](productToEdit.Id)
		_entities.ApplyPropertyChanges(originalProduct.EntityKey.EntitySetName, productToEdit)
		_entities.SaveChanges()

	End Sub

	Public Sub Delete(ByVal productToDelete As Product) Implements IProductRepository.Delete 
		Dim originalProduct = [Get](productToDelete.Id)
		_entities.DeleteObject(originalProduct)
		_entities.SaveChanges()
	End Sub

	#End Region

End Class
