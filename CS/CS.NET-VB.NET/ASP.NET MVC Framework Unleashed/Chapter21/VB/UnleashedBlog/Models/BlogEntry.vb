Public Class BlogEntry
    Private privateId As Integer
    Public Property Id() As Integer
        Get
            Return privateId
        End Get
        Set(ByVal value As Integer)
            privateId = value
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
    Private privateDescription As String
    Public Property Description() As String
        Get
            Return privateDescription
        End Get
        Set(ByVal value As String)
            privateDescription = value
        End Set
    End Property
    Private privateDateModified As Nullable(Of DateTime)
    Public Property DateModified() As Nullable(Of DateTime)
        Get
            Return privateDateModified
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            privateDateModified = value
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
    Private privateName As String
    Public Property Name() As String
        Get
            Return privateName
        End Get
        Set(ByVal value As String)
            privateName = value
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
    Private privateTitle As String
    Public Property Title() As String
        Get
            Return privateTitle
        End Get
        Set(ByVal value As String)
            privateTitle = value
        End Set
    End Property
    Private privateCommentCount As Integer
    Public Property CommentCount() As Integer
        Get
            Return privateCommentCount
        End Get
        Set(ByVal value As Integer)
            privateCommentCount = value
        End Set
    End Property

    Private privateComments As List(Of Comment)
    Public Property Comments() As List(Of Comment)
        Get
            Return privateComments
        End Get
        Set(ByVal value As List(Of Comment))
            privateComments = value
        End Set
    End Property

End Class
