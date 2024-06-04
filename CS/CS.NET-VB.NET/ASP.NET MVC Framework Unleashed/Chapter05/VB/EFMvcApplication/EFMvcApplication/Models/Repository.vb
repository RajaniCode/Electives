Imports GenericRepository
Imports System.Data.Objects

Public Class Repository
    Inherits EFGenericRepository
    Implements IRepository

    Sub New(ByVal context As ObjectContext)
        MyBase.New(context)
    End Sub

    Public Function GetProductCount() As Integer Implements IRepository.GetProductCount
        Return Me.List(Of Product)().Count()
    End Function

End Class
