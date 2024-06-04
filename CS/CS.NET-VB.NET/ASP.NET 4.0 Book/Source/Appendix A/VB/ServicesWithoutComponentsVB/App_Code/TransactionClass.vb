Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.EnterpriseServices

Public Class TransactionClass
    Public Function AddDetails(ByVal prodName As String, ByVal prodDescription As String,
    ByVal prodType As String) As String
        Dim config As New ServiceConfig()
        config.Transaction = TransactionOption.Required
        ServiceDomain.Enter(config)
        Try
            Dim prod As New Products()
            Dim ProdID As Integer = prod.AddProducts(prodName, prodDescription)
            Dim pType As New ProductType()
            pType.AddProductType(ProdID, prodType)
        Catch
            Throw
        Finally
            ServiceDomain.Leave()
        End Try
        Return "Data entered successfully"
    End Function

End Class
