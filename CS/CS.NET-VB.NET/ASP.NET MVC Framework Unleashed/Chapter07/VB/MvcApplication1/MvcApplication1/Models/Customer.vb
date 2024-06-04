Public Class Customer

    Private _id As Integer
    Private _firstName As String
    Private _lastName As String
    Private _address As Address

    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property FirstName() As String
        Get
            Return _firstName
        End Get
        Set(ByVal value As String)
            _firstName = value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
        End Set
    End Property

    Public Property Address() As Address
        Get
            Return _address
        End Get
        Set(ByVal value As Address)
            _address = value
        End Set
    End Property
End Class

Public Class Address

    Private _street As String
    Private _city As String
    Private _zip As String


    Public Property Street() As String
        Get
            Return _street
        End Get
        Set(ByVal value As String)
            _street = value
        End Set
    End Property
    Public Property City() As String
        Get
            Return _city
        End Get
        Set(ByVal value As String)
            _city = value
        End Set
    End Property
    Public Property ZIP() As String
        Get
            Return _zip
        End Get
        Set(ByVal value As String)
            _zip = value
        End Set
    End Property
End Class
