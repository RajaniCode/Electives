Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public Class Product
    Private privateId As Integer
    Public Property Id() As Integer
        Get
            Return privateId
        End Get
        Set(ByVal value As Integer)
            privateId = value
        End Set
    End Property
    Private privateName As String
    Public Property Name() As String
        Get
            Return privateName
        End Get
        Set(ByVal value As String)
            privateName = value
        End Set
    End Property
    Private privatePrice As Decimal
    Public Property Price() As Decimal
        Get
            Return privatePrice
        End Get
        Set(ByVal value As Decimal)
            privatePrice = value
        End Set
    End Property
End Class
