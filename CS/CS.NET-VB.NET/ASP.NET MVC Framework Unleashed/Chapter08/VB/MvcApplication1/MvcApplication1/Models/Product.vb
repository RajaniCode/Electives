Imports System.ComponentModel

Partial Public Class Product
    Implements IDataErrorInfo

    Private _errors As New Dictionary(Of String, String)()

    Private Sub OnNameChanging(ByVal value As String)
        If value.Trim() = String.Empty Then
            _errors.Add("Name", "Name is required.")
        End If
    End Sub

    Private Sub OnPriceChanging(ByVal value As Decimal)
        If value <= 0D Then
            _errors.Add("Price", "Price must be greater than 0.")
        End If
    End Sub

#Region "IDataErrorInfo Members"

    Public ReadOnly Property [Error]() As String Implements IDataErrorInfo.Error
        Get
            Return String.Empty
        End Get
    End Property

    Public ReadOnly Property Item(ByVal columnName As String) As String Implements IDataErrorInfo.Item
        Get
            If _errors.ContainsKey(columnName) Then
                Return _errors(columnName)
            End If
            Return String.Empty
        End Get
    End Property

#End Region


End Class
