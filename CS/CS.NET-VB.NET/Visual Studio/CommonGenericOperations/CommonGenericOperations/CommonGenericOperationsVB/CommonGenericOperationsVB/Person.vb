Imports System
Imports System.Collections.Generic
Imports System.Text


Public Class Person
    Public Sub New()

    End Sub

    Public Sub New(ByVal id As Integer, ByVal first_name As String, ByVal mid_name As String, ByVal last_name As String, ByVal age As Short, ByVal sex As Char)
        Me.p_id = id
        Me.first_name = first_name
        Me.mid_name = mid_name
        Me.last_name = last_name
        Me.p_age = age
        Me.p_sex = sex
    End Sub

    Private p_id As Integer = -1
    Private first_name As String = String.Empty
    Private mid_name As String = String.Empty
    Private last_name As String = String.Empty
    Private p_age As Short = 0
    Private p_sex As Nullable(Of Char) = Nothing

    Public Property ID() As Integer
        Get
            Return p_id
        End Get
        Set(ByVal value As Integer)
            p_id = value
        End Set
    End Property

    Public Property FirstName() As String
        Get
            Return first_name
        End Get
        Set(ByVal value As String)
            first_name = value
        End Set

    End Property

    Public Property MiddleName() As String
        Get
            Return mid_name
        End Get
        Set(ByVal value As String)
            mid_name = value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return last_name
        End Get
        Set(ByVal value As String)
            last_name = value
        End Set
    End Property

    Public Property Age() As Short
        Get
            Return p_age
        End Get
        Set(ByVal value As Short)
            p_age = value
        End Set
    End Property

    Public Property Sex() As Nullable(Of Char)
        Get
            Return p_sex
        End Get
        Set(ByVal value As Nullable(Of Char))
            p_sex = value
        End Set
    End Property
End Class