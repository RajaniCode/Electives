Public Class ProductController
	Inherits Controller

	Private _repository As IProductRepository

	Public Sub New()
		Me.New(New ProductRepository())
	End Sub

	Public Sub New(ByVal repository As IProductRepository)
		_repository = repository
	End Sub


	'
	' GET: /Product/

	Public Function Index() As ActionResult
		Return View(_repository.List())
	End Function

	'
	' GET: /Product/Details/5

	Public Function Details(ByVal id As Integer) As ActionResult
		Return View(_repository.Get(id))
	End Function

	'
	' GET: /Product/Create

	Public Function Create() As ActionResult
		Return View()
	End Function

	'
	' POST: /Product/Create

	<AcceptVerbs(HttpVerbs.Post)> _
	Public Function Create(ByVal productToCreate As Product) As ActionResult
		Try
			_repository.Create(productToCreate)
			Return RedirectToAction("Index")
		Catch
			Return View()
		End Try
	End Function

	'
	' GET: /Product/Edit/5

	Public Function Edit(ByVal id As Integer) As ActionResult
		Return View(_repository.Get(id))
	End Function

	'
	' POST: /Product/Edit/5

	<AcceptVerbs(HttpVerbs.Post)> _
	Public Function Edit(ByVal productToEdit As Product) As ActionResult
		Try
			_repository.Edit(productToEdit)
			Return RedirectToAction("Index")
		Catch
			Return View()
		End Try
	End Function

	'
	' GET: /Product/Delete/5

	Public Function Delete(ByVal id As Integer) As ActionResult
		Return View(_repository.Get(id))
	End Function

	'
	' POST: /Product/Delete

	<AcceptVerbs(HttpVerbs.Post)> _
	Public Function Delete(ByVal productToDelete As Product) As ActionResult
		Try
			_repository.Delete(productToDelete)
			Return RedirectToAction("Index")
		Catch
			Return View()
		End Try
	End Function

End Class
