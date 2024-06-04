Public Class CatalogController
    Inherits System.Web.Mvc.Controller


    Function Create() As ActionResult
        Return View()
    End Function

    Function Delete() As ActionResult
        Return View()
    End Function

    Protected Overrides Sub HandleUnknownAction(ByVal actionName As String)
        ViewData("actionName") = actionName
        View("Unknown").ExecuteResult(Me.ControllerContext)
    End Sub


End Class
