Public Class BlogEntry

    Private _id As Integer
    Private _author As String
    Private _description As String
    Private _dateModified As DateTime?
    Private _datePublished As DateTime
    Private _name As String
    Private _text As String
    Private _title As String

    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property Author() As String
        Get
            Return _author
        End Get
        Set(ByVal value As String)
            _author = value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
        End Set
    End Property

    Public Property DateModified() As DateTime?
        Get
            Return _dateModified
        End Get
        Set(ByVal value As DateTime?)
            _dateModified = value
        End Set
    End Property

    Public Property DatePublished() As DateTime
        Get
            Return _datePublished
        End Get
        Set(ByVal value As DateTime)
            _datePublished = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Public Property Text() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property

    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
        End Set
    End Property

End Class
