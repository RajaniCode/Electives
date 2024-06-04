Public Class PagedList(Of T)
	Inherits List(Of T)
    Implements IPagedList

    Private _pageIndex As Integer
    Private _pageSize As Integer
    Private _sortExpression As String
    Private _totalItemCount As Integer
    Private _totalPageCount As Integer

	Public Sub New(ByVal items As IEnumerable(Of T), ByVal pageIndex As Integer, ByVal pageSize As Integer, ByVal totalItemCount As Integer, ByVal sortExpression As String)
		Me.AddRange(items)
		Me.PageIndex = pageIndex
		Me.PageSize = pageSize
		Me.SortExpression = sortExpression
		Me.TotalItemCount = totalItemCount
        _totalPageCount = CInt(Fix(Math.Ceiling(totalItemCount / CDbl(pageSize))))
	End Sub

    Public Property PageIndex() As Integer Implements IPagedList.PageIndex
        Get
            Return _pageIndex
        End Get
        Set(ByVal value As Integer)
            _pageIndex = value
        End Set
    End Property
    Public Property PageSize() As Integer Implements IPagedList.PageSize
        Get
            Return _pageSize
        End Get
        Set(ByVal value As Integer)
            _pageSize = value
        End Set
    End Property

    Public Property SortExpression() As String Implements IPagedList.SortExpression
        Get
            Return _sortExpression
        End Get
        Set(ByVal value As String)
            _sortExpression = value
        End Set
    End Property
    Public Property TotalItemCount() As Integer Implements IPagedList.TotalItemCount
        Get
            Return _totalItemCount
        End Get
        Set(ByVal value As Integer)
            _totalItemCount = value
        End Set
    End Property
    Public ReadOnly Property TotalPageCount() As Integer Implements IPagedList.TotalPageCount
        Get
            Return _totalPageCount
        End Get
    End Property

End Class
