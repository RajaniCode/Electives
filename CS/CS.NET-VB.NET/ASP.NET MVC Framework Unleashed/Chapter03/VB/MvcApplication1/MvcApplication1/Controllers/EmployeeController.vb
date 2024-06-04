Public Class EmployeeController
    Inherits System.Web.Mvc.Controller

    Private _repository As New EmployeeRepository()

    ' GET: /Employee/Create
    Function Index() As ActionResult
        Return View()
    End Function


    ' GET: /Employee/Create
    <AcceptVerbs(HttpVerbs.Get)> _
    Function Create() As ActionResult
        Return View()
    End Function

    ' POST: /Employee/Create
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal employeeToCreate As Employee) As ActionResult
        Try
            _repository.InsertEmployee(employeeToCreate)
            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

    ' DELETE: /Employee/Create
    <AcceptVerbs(HttpVerbs.Delete)> _
    Function Delete(ByVal id As Integer) As ActionResult
        _repository.DeleteEmployee(id)
        Return Json(True)
    End Function


End Class
