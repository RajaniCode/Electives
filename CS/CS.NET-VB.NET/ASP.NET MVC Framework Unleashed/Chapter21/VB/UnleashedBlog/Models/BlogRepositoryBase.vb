

Public MustInherit Class BlogRepositoryBase

    ' Blog Entry Methods
    Public MustOverride Sub CreateBlogEntry(ByVal blogEntryToCreate As BlogEntry)
    Protected MustOverride Function QueryBlogEntries() As IQueryable(Of BlogEntry)


    Public Overridable Function GetBlogEntry(ByVal id As Integer) As BlogEntry
        Dim blogEntry = Me.QueryBlogEntries().Where(Function(e) e.Id = id).Select(Function(e) e).FirstOrDefault()

        blogEntry.Comments = ListComments(blogEntry.Id)

        Return blogEntry
    End Function

    Public Overridable Function GetBlogEntry(ByVal year As Integer, ByVal month As Integer, ByVal day As Integer, ByVal name As String) As BlogEntry
        Dim blogEntry = (Me.QueryBlogEntries().Where(Function(e) e.DatePublished.Year = year).Where(Function(e) e.DatePublished.Month = month).Where(Function(e) e.DatePublished.Day = day).Where(Function(e) e.Name = name)).FirstOrDefault()

        blogEntry.Comments = ListComments(blogEntry.Id)

        Return blogEntry
    End Function


    Public Overridable Function ListBlogEntries(ByVal page As Nullable(Of Integer), ByVal year As Nullable(Of Integer), ByVal month As Nullable(Of Integer), ByVal day As Nullable(Of Integer)) As PagedList(Of BlogEntry)
        Dim query = Me.QueryBlogEntries()

        If year.HasValue Then
            query = query.Where(Function(e) e.DatePublished.Year = year.Value)
        End If
        If month.HasValue Then
            query = query.Where(Function(e) e.DatePublished.Month = month.Value)
        End If
        If day.HasValue Then
            query = query.Where(Function(e) e.DatePublished.Day = day.Value)
        End If

        Return query.OrderByDescending(Function(e) e.DatePublished).ToPagedList(page, 5)
    End Function

    ' Comment Methods

    Public MustOverride Sub CreateComment(ByVal commentToCreate As Comment)
    Protected MustOverride Function QueryComments() As IQueryable(Of Comment)

    Protected Overridable Function ListComments(ByVal blogEntryId As Integer) As List(Of Comment)
        Return Me.QueryComments().Where(Function(c) c.BlogEntryId = blogEntryId).OrderBy(Function(c) c.DatePublished).ToList()
    End Function



    ' Archive Info Methods
    Public Function ListBlogEntriesByMonth() As IList(Of ArchiveInfo)
        Dim result = From e In Me.QueryBlogEntries() _
                    Group By Year = e.DatePublished.Year, Month = e.DatePublished.Month _
                     Into g = Group, Count() _
                    Order By Year Descending, Month Descending _
                     Select New ArchiveInfo With {.Year = Year, .Month = Month, .Count = g.Count()}


        Return result.Take(10).ToList()
    End Function


End Class
