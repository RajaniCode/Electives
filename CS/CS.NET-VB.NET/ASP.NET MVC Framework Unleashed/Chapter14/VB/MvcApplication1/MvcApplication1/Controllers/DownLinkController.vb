Public Class ProductsVDM

    Private _categories As IEnumerable(Of Category)
    Private _products As IEnumerable(Of Product)

    Public Sub New(ByVal categories As IEnumerable(Of Category), ByVal products As IEnumerable(Of Product))
        _categories = categories
        _products = products
    End Sub

    Public ReadOnly Property Categories() As IEnumerable(Of Category)
        Get
            Return _categories
        End Get
    End Property

    Public ReadOnly Property Products() As IEnumerable(Of Product)
        Get
            Return _products
        End Get
    End Property
End Class

Public Class DownLinkController
    Inherits Controller

    Private _entities As New ProductsDBEntities()

    Public Function Index() As ActionResult
        Dim categories = _entities.CategorySet.ToList()
        Dim products = New List(Of Product)()
        Return View(New ProductsVDM(categories, products))
    End Function


    Public Function Details(ByVal id As Integer) As ActionResult
        Dim products = From p In _entities.ProductSet _
                       Where p.CategoryId = id _
                       Select p

        If Request.IsAjaxRequest() Then
            Return PartialView("Details", products)
        Else
            Dim categories = _entities.CategorySet.ToList()
            Return View("Index", New ProductsVDM(categories, products))
        End If

    End Function


End Class
