Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Public Class Products


    Public Function AddProducts(ByVal name As String, ByVal description As String) As Integer
        Dim productID As Integer
        Dim connString As String = "Data Source=PUNEET-PC;Initial Catalog=componentapp;Integrated Security=True"
        Dim commandName As String = "AddProducts"
        Using conn As New SqlConnection(connString)
            conn.Open()
            Dim command As New SqlCommand(commandName, conn)
            command.CommandType = CommandType.StoredProcedure
            Dim paramName As New SqlParameter("@Name", SqlDbType.VarChar, 50)
            paramName.Direction = ParameterDirection.Input
            paramName.Value = name
            command.Parameters.Add(paramName)
            Dim paramDesc As New SqlParameter("@Description", SqlDbType.VarChar, 250)
            paramDesc.Direction = ParameterDirection.Input
            paramDesc.Value = description
            command.Parameters.Add(paramDesc)
            Dim paramReturnValue As New SqlParameter("@@identity", SqlDbType.VarChar, 250)
            paramReturnValue.Direction = ParameterDirection.ReturnValue
            command.Parameters.Add(paramReturnValue)
            command.ExecuteNonQuery()
            productID = CInt(Fix(command.Parameters("@@identity").Value))
            Console.WriteLine(productID)
            Console.ReadLine()
        End Using
        Return productID
    End Function

End Class
