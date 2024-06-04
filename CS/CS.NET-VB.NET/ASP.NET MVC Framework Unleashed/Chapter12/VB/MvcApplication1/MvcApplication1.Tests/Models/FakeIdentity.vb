Imports System.Security.Principal

Public Class FakeIdentity
    Implements IIdentity

    Private _name As String

    Public Sub New(ByVal name As String)
        _name = name
    End Sub

#Region "IIdentity Members"

    Public ReadOnly Property AuthenticationType() As String Implements IIdentity.AuthenticationType
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public ReadOnly Property IsAuthenticated() As Boolean Implements IIdentity.IsAuthenticated
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public ReadOnly Property Name() As String Implements IIdentity.Name
        Get
            Return _name
        End Get
    End Property

#End Region

End Class
