Public Class SelectorController
    Inherits Controller

    Private _entities As New ProductsDBEntities()

    Public Function Index()
        Dim categories = _entities.CategorySet.ToList()
        Dim products = New List(Of Product)()
        Return View(New ProductsVDM(categories, products))
    End Function

    <AcceptAjax(), ActionName("Details")> _
    Public Function Details_Uplevel(ByVal id As Integer) As ActionResult
        Dim products = From p In _entities.ProductSet _
                       Where p.CategoryId = id _
                       Select p

        Return PartialView("Details", products)
    End Function

    <ActionName("Details")> _
    Public Function Details_Downlevel(ByVal id As Integer) As ActionResult
        Dim categories = _entities.CategorySet.ToList()
        Dim products = From p In _entities.ProductSet _
                       Where p.CategoryId = id _
                       Select p

        Return View("Index", New ProductsVDM(categories, products))
    End Function

End Class