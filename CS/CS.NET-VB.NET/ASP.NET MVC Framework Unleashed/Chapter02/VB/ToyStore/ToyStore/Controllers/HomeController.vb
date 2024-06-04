Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private _dataModel As New ToyStoreDBEntities()


    '
    ' GET: /Home/

    Function Index() As ActionResult
        Return View(_dataModel.ProductSet.ToList())
    End Function


    '
    ' GET: /Home/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Home/Create

    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(<Bind(Exclude:="Id")> ByVal productToCreate As Product) As ActionResult

        If Not ModelState.IsValid Then
            Return View()
        End If

        Try
            _dataModel.AddToProductSet(productToCreate)
            _dataModel.SaveChanges()

            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function


End Class
