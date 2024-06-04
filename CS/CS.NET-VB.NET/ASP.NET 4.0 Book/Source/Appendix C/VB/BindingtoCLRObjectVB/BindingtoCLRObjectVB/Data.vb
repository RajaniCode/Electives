Imports System
Imports System.Collections.Generic

Namespace BindingtoCLRObject
    Friend Class Data
        Public Sub New(ByVal name As String, ByVal age As String, ByVal profile As String,
         ByVal id As String, ByVal ParamArray names As String())
            Me.name_Renamed = name
            Me.age_Renamed = age
            Me.profile_Renamed = profile
            Me.id = id
            For Each Employee As String In names
                Me.names_Renamed.Add(name)
            Next Employee
        End Sub
        Public Sub New()
            Me.New("", "", "", "")
        End Sub
        Private name_Renamed As String
        Public Property Name() As String
            Get
                Return name_Renamed
            End Get
            Set(ByVal value As String)
                name_Renamed = value
            End Set
        End Property
        Private age_Renamed As String
        Public Property Age() As String
            Get
                Return age_Renamed
            End Get
            Set(ByVal value As String)
                age_Renamed = value
            End Set
        End Property
        Private profile_Renamed As String
        Public Property Profile() As String
            Get
                Return profile_Renamed
            End Get
            Set(ByVal value As String)
                profile_Renamed = value
            End Set
        End Property
        Private id As String
        Public Property EmployeeID() As String
            Get
                Return id
            End Get
            Set(ByVal value As String)
                id = value
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return name_Renamed
        End Function
        Private ReadOnly names_Renamed As List(Of String) = New List(Of String)()
        Public ReadOnly Property Names() As String()
            Get
                Return names_Renamed.ToArray()
            End Get
        End Property

    End Class
End Namespace