Public Interface IPagedList
    Property PageIndex() As Integer
    Property PageSize() As Integer
    Property SortExpression() As String
    Property TotalItemCount() As Integer
    ReadOnly Property TotalPageCount() As Integer
End Interface
