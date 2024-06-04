Public Class SelectedController
    Inherits Controller

    Private _entities As New ProductsDBEntities()

    Public Function Index() As ActionResult
        Return View(_entities.CategorySet.ToList())
    End Function


    Public Function Details(ByVal id As Integer) As ActionResult
        Dim products = From p In _entities.ProductSet _
                       Where p.CategoryId = id _
                       Select p
        Return PartialView("Details", products)
    End Function


End Class
