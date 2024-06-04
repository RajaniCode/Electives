Imports GenericRepository

Public Class HomeController
    Inherits Controller

    Private _repository As IGenericRepository

    Public Sub New()
        Me.New(New EFGenericRepository(New ToyStoreDBEntities()))
    End Sub

    Public Sub New(repository As IGenericRepository)
        _repository = repository
    End Sub


    '
    ' GET: /Home/

    Public Function Index() As ActionResult
        Return View(_repository.List(Of Product)().ToList())
    End Function


    '
    ' GET: /Home/Create

    Public Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Home/Create

    <AcceptVerbs(HttpVerbs.Post)> _
    Public Function Create(<Bind(Exclude:="Id")> ByVal productToCreate As Product) As ActionResult
        If productToCreate.Name.Trim().Length = 0 Then
            ModelState.AddModelError("Name", "Product name is required.")
            Return View()
        End If
        Try
            _repository.Create(Of Product)(productToCreate)
            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

    '
    ' GET: /Home/Edit/5

    Public Function Edit(ByVal id As Integer) As ActionResult
        Return View(_repository.Get(Of Product)(id))
    End Function

    '
    ' POST: /Home/Edit/5

    <AcceptVerbs(HttpVerbs.Post)> _
    Public Function Edit(ByVal productToEdit As Product) As ActionResult
        Try
            _repository.Edit(Of Product)(productToEdit)
            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function


    '
    ' GET: /Home/Delete/5

    Public Function Delete(ByVal id As Integer) As ActionResult
        Return View(_repository.Get(Of Product)(id))
    End Function

    '
    ' POST: /Home/Delete/5

    <AcceptVerbs(HttpVerbs.Post)> _
    Public Function Delete(ByVal productToDelete As Product) As ActionResult
        _repository.Delete(Of Product)(productToDelete)
        Return RedirectToAction("Index")
    End Function


End Class
