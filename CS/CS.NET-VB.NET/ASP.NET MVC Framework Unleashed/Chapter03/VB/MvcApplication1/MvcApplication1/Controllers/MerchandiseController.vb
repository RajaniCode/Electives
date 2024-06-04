Public Class MerchandiseController
    Inherits System.Web.Mvc.Controller

    Private _repository As New MerchandiseRepository()

    ' GET: /Merchandise/Edit
    <ActionName("Edit")> _
    <AcceptVerbs(HttpVerbs.Get)> _
    Function Edit_GET(ByVal merchandiseToEdit As Merchandise) As ActionResult
        Return View(merchandiseToEdit)
    End Function

    ' POST: /Merchandise/Edit
    <ActionName("Edit")> _
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Edit_POST(ByVal merchandiseToEdit As Merchandise) As ActionResult
        Try
            _repository.Edit(merchandiseToEdit)
            Return RedirectToAction("Edit")
        Catch
            Return View()
        End Try
    End Function

End Class
