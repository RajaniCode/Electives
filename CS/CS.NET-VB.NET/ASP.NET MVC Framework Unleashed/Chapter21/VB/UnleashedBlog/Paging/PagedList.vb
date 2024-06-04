Public Class PagedList(Of T)
    Inherits List(Of T)
    Implements IPagedList

    Public Sub New(ByVal items As IEnumerable(Of T), ByVal pageIndex As Integer, ByVal pageSize As Integer, ByVal totalItemCount As Integer, ByVal sortExpression As String)
        Me.AddRange(items)
        Me.PageIndex = pageIndex
        Me.PageSize = pageSize
        Me.SortExpression = sortExpression
        Me.TotalItemCount = totalItemCount
        privateTotalPageCount = CInt(Fix(Math.Ceiling(totalItemCount / CDbl(pageSize))))
    End Sub

    Private privatePageIndex As Integer
    Public Property PageIndex() As Integer Implements IPagedList.PageIndex
        Get
            Return privatePageIndex
        End Get
        Set(ByVal value As Integer)
            privatePageIndex = value
        End Set
    End Property
    Private privatePageSize As Integer
    Public Property PageSize() As Integer Implements IPagedList.PageSize
        Get
            Return privatePageSize
        End Get
        Set(ByVal value As Integer)
            privatePageSize = value
        End Set
    End Property
    Private privateSortExpression As String
    Public Property SortExpression() As String Implements IPagedList.SortExpression
        Get
            Return privateSortExpression
        End Get
        Set(ByVal value As String)
            privateSortExpression = value
        End Set
    End Property
    Private privateTotalItemCount As Integer
    Public Property TotalItemCount() As Integer Implements IPagedList.TotalItemCount
        Get
            Return privateTotalItemCount
        End Get
        Set(ByVal value As Integer)
            privateTotalItemCount = value
        End Set
    End Property
    Private privateTotalPageCount As Integer
    Public ReadOnly Property TotalPageCount() As Integer Implements IPagedList.TotalPageCount
        Get
            Return privateTotalPageCount
        End Get
    End Property

End Class
