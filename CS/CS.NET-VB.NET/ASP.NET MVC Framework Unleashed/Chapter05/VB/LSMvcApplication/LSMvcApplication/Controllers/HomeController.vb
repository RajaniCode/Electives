Imports GenericRepository

Public Class HomeController
    Inherits Controller

    Private _repository As IGenericRepository


    Public Sub New()
        _repository = New LSGenericRepository(New DataModelDataContext())
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
        Try
            _repository.Create(Of Product)(productToCreate)
            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function



End Class
