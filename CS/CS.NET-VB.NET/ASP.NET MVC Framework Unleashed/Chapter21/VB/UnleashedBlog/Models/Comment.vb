Public Class Comment
    Private privateId As Integer
    Public Property Id() As Integer
        Get
            Return privateId
        End Get
        Set(ByVal value As Integer)
            privateId = value
        End Set
    End Property
    Private privateBlogEntryId As Integer
    Public Property BlogEntryId() As Integer
        Get
            Return privateBlogEntryId
        End Get
        Set(ByVal value As Integer)
            privateBlogEntryId = value
        End Set
    End Property
    Private privateTitle As String
    Public Property Title() As String
        Get
            Return privateTitle
        End Get
        Set(ByVal value As String)
            privateTitle = value
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
    Private privateUrl As String
    Public Property Url() As String
        Get
            Return privateUrl
        End Get
        Set(ByVal value As String)
            privateUrl = value
        End Set
    End Property
    Private privateEmail As String
    Public Property Email() As String
        Get
            Return privateEmail
        End Get
        Set(ByVal value As String)
            privateEmail = value
        End Set
    End Property
    Private privateText As String
    Public Property Text() As String
        Get
            Return privateText
        End Get
        Set(ByVal value As String)
            privateText = value
        End Set
    End Property
    Private privateDatePublished As DateTime
    Public Property DatePublished() As DateTime
        Get
            Return privateDatePublished
        End Get
        Set(ByVal value As DateTime)
            privateDatePublished = value
        End Set
    End Property
End Class
