Imports Microsoft.VisualBasic
Imports System.Web.Profile
Public Class Classprofile
    Private Dy As String
    Private Mnth As String
    Private Yr As String
    Public Property Day() As String
        Get
            Return Dy
        End Get
        Set(ByVal value As String)
            Dy = value
        End Set
    End Property
    Public Property Month() As String
        Get
            Return Mnth
        End Get

        Set(ByVal value As String)
            Mnth = value
        End Set
    End Property

    Public Property Year() As String
        Get
            Return Yr
        End Get

        Set(ByVal value As String)
            Yr = value
        End Set
    End Property

End Class
