Public Interface IProductRepository
	Function List() As IEnumerable(Of Product)
	Function [Get](ByVal id As Integer) As Product
	Sub Create(ByVal productToCreate As Product)
	Sub Edit(ByVal productToEdit As Product)
	Sub Delete(ByVal productToDelete As Product)
End Interface
