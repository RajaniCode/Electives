Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public Class ArticlesList

    Private privateTitle As String
    Public Property Title() As String
        Get
            Return privateTitle
        End Get
        Set(ByVal value As String)
            privateTitle = value
        End Set
    End Property

    Private privateLink As String
    Public Property Link() As String
        Get
            Return privateLink
        End Get
        Set(ByVal value As String)
            privateLink = value
        End Set
    End Property

    Private privateDescription As String
    Public Property Description() As String
        Get
            Return privateDescription
        End Get
        Set(ByVal value As String)
            privateDescription = value
        End Set
    End Property

    Private privateAuthor As String
    Public Property Author() As String
        Get
            Return privateAuthor
        End Get
        Set(ByVal value As String)
            privateAuthor = value
        End Set
    End Property
End Class