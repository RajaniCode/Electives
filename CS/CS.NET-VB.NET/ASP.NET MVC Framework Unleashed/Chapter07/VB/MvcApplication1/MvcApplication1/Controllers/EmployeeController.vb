Public Class EmployeeController
    Inherits System.Web.Mvc.Controller

    ' GET: /Employee/Create
    Function Create() As ActionResult
        Return View()
    End Function

    ' POST: /Employee/Create
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal employeeToCreate As Employee) As ActionResult
        If Not ModelState.IsValid Then
            Return View()
        End If

        ' Add employee to database
        Return RedirectToAction("Index")
    End Function


End Class
