Public Module PageLinqExtensions

    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToPagedList(Of T)(ByVal allItems As IQueryable(Of T), ByVal pageIndex As Integer?, ByVal pageSize As Integer) As PagedList(Of T)
        Return ToPagedList(Of T)(allItems, pageIndex, pageSize, String.Empty)
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToPagedList(Of T)(ByVal allItems As IQueryable(Of T), ByVal pageIndex As Integer?, ByVal pageSize As Integer, ByVal sort As String) As PagedList(Of T)
        Dim truePageIndex = If(pageIndex.HasValue, pageIndex.Value, 0)
        Dim itemIndex = truePageIndex * pageSize
        Dim pageOfItems = allItems.Skip(itemIndex).Take(pageSize)
        Dim totalItemCount = allItems.Count()
        Return New PagedList(Of T)(pageOfItems, truePageIndex, pageSize, totalItemCount, sort)
    End Function

End Module
