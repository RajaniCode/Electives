Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Public Class ProductType
    Public Function AddProductType(ByVal productID As Integer, ByVal productType As String) As Integer
        Dim productTypeID As Integer
        Dim connString As String = "Data Source=PUNEET-PC;Initial Catalog=componentapp;Integrated Security=True"
        Dim commandName As String = "AddProductTypes"
        Using conn As New SqlConnection(connString)
            conn.Open()
            Dim command As New SqlCommand(commandName, conn)
            command.CommandType = CommandType.StoredProcedure
            Dim paramProductID As New SqlParameter("@ProductID", SqlDbType.Int)
            paramProductID.Direction = ParameterDirection.Input
            paramProductID.Value = productID
            command.Parameters.Add(paramProductID)
            Dim paramProductType As New SqlParameter("@ProductType",
               SqlDbType.VarChar, 50)
            paramProductType.Direction = ParameterDirection.Input
            paramProductType.Value = productType
            command.Parameters.Add(paramProductType)
            Dim paramReturnValue As New SqlParameter("@@identity", SqlDbType.VarChar,
               250)
            paramReturnValue.Direction = ParameterDirection.ReturnValue
            command.Parameters.Add(paramReturnValue)
            command.ExecuteNonQuery()
            productTypeID = CInt(Fix(command.Parameters("@@identity").Value))
        End Using
        Return productTypeID
    End Function

End Class
