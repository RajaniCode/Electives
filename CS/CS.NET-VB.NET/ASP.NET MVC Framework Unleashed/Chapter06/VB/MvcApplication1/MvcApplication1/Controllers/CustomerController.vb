
Public Class CustomerController
    Inherits System.Web.Mvc.Controller

    Private _entities As New CustomersDBEntities()

    Function Index() As ActionResult
        ViewData("CustomerId") = New SelectList(_entities.CustomerSet.ToList(), "Id", "LastName")
        Return View()
    End Function

    Function Register() As ActionResult
        Return View()
    End Function
    

    Function Create() As ActionResult
        Return View()
    End Function
  
    Function Delete() As ActionResult
        Return View()
    End Function

    Function List() As ActionResult
        ViewData("Customers") = From c In _entities.CustomerSet _
                                Select c.LastName
        Return View()
    End Function

End Class
