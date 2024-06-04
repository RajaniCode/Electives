Imports System.IO

Public Class ContentController
    Inherits System.Web.Mvc.Controller

    ' GET: /Content/Create
    Function Create() As ActionResult
        Return View()
    End Function

    ' POST: /Content/Create
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal upload As HttpPostedFileBase) As ActionResult
        ' Save File
        Dim fileName = Path.GetFileName(upload.FileName)
        upload.SaveAs(Server.MapPath("~/Uploads/" & fileName))
        Return RedirectToAction("Create")
    End Function


End Class
