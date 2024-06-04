Public Class UserModelBinder
    Implements IModelBinder

    Public Function BindModel(ByVal controllerContext As ControllerContext, ByVal bindingContext As ModelBindingContext) As Object Implements IModelBinder.BindModel
        Return controllerContext.HttpContext.User
    End Function

End Class
