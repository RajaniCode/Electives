Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private _entities As New ProductsDBEntities()

    '
    ' GET: /Home/

    Function Index() As ActionResult
Dim results = From p In _entities.ProductSet _
      Where p.Price > 10.0 _
      Order By p.Name _
      Select p

        Return View(_entities.ProductSet.ToList())
    End Function

    '
    ' GET: /Home/Details/5

    Function Details(ByVal id As Integer) As ActionResult
        Dim result = (From p In _entities.ProductSet _
                      Where p.Id = id _
                      Select p).FirstOrDefault()

        Return View(result)
    End Function

    '
    ' GET: /Home/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Home/Create

    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(productToCreate As Product) As ActionResult
        Try
            _entities.AddToProductSet(productToCreate)
            _entities.SaveChanges()
            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

    '
    ' GET: /Home/Edit/5

    Function Edit(ByVal id As Integer) As ActionResult
        Dim productToEdit = (From p In _entities.ProductSet _
                      Where p.Id = id _
                      Select p).FirstOrDefault()
        Return View(productToEdit)
    End Function

    '
    ' POST: /Home/Edit/5

    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit(productToEdit As Product) As ActionResult
        Try
            Dim originalProduct = (From p In _entities.ProductSet _
                      Where p.Id = productToEdit.Id _
                      Select p).FirstOrDefault()
            _entities.ApplyPropertyChanges(originalProduct.EntityKey.EntitySetName, productToEdit)
            _entities.SaveChanges()
            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

    '
    ' GET: /Home/Delete/5

    Function Delete(ByVal id As Integer) As ActionResult
        Dim productToDelete = (From p In _entities.ProductSet _
                      Where p.Id = id _
                      Select p).FirstOrDefault()
        Return View(productToDelete)
    End Function

    '
    ' POST: /Home/Delete

    <AcceptVerbs(HttpVerbs.Post)> _
    Function Delete(productToDelete As Product) As ActionResult
        Try
            Dim originalProduct = (From p In _entities.ProductSet _
                      Where p.Id = productToDelete.Id _
                      Select p).FirstOrDefault()
            _entities.DeleteObject(originalProduct)
            _entities.SaveChanges()
            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function


End Class
