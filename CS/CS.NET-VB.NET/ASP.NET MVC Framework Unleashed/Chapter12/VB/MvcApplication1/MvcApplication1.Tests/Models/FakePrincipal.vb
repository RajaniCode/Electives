Imports System.Security.Principal

Public Class FakePrincipal
    Implements IPrincipal

    Private _name As String

    Public Sub New(ByVal name As String)
        _name = name
    End Sub

#Region "IPrincipal Members"

    Public ReadOnly Property Identity() As IIdentity Implements IPrincipal.Identity
        Get
            Return New FakeIdentity(_name)
        End Get
    End Property

    Public Function IsInRole(ByVal role As String) As Boolean Implements IPrincipal.IsInRole
        Throw New NotImplementedException()
    End Function

#End Region
End Class