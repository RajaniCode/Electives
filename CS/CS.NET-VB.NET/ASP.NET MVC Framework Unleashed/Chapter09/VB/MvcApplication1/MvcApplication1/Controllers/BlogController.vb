Public Class BlogController
    Inherits System.Web.Mvc.Controller

    Function Archive(ByVal entryDate As DateTime) As String
        Return entryDate.ToString()
    End Function

End Class
