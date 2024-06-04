Public Class ProductController
    Inherits System.Web.Mvc.Controller

    private _entities As New ToyStoreDBEntities 

    Function Index() As ActionResult
        Return View(_entities.ProductSet.ToList())
    End Function

    
    Function Index2() As ActionResult
        Return View(_entities.ProductSet.ToList())
    End Function

End Class
