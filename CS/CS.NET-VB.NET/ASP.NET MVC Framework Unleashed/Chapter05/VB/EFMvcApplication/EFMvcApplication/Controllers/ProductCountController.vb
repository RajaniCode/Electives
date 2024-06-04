Public Class ProductCountController
	Inherits Controller

	Private _repository As IRepository

	Public Sub New()
		_repository = New Repository(New ToyStoreDBEntities())
	End Sub

	'
	' GET: /ProductCount/

	Public Function Index() As Integer
		Return _repository.GetProductCount()
	End Function

End Class
