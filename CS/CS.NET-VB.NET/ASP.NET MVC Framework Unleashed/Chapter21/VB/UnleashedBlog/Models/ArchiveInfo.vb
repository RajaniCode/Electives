Public Class ArchiveInfo
    Private privateYear As Integer
    Public Property Year() As Integer
        Get
            Return privateYear
        End Get
        Set(ByVal value As Integer)
            privateYear = value
        End Set
    End Property

    Private privateMonth As Integer
    Public Property Month() As Integer
        Get
            Return privateMonth
        End Get
        Set(ByVal value As Integer)
            privateMonth = value
        End Set
    End Property

    Private privateCount As Integer
    Public Property Count() As Integer
        Get
            Return privateCount
        End Get
        Set(ByVal value As Integer)
            privateCount = value
        End Set
    End Property
End Class
