
Public Class BlogEntryFactory

    Public Shared Function [Get]() As BlogEntry
        Dim blogEntry = New BlogEntry()
        blogEntry.Title = "Test Entry"
        blogEntry.Name = "Test Entry"
        blogEntry.Text = "Blog text"
        blogEntry.DatePublished = New DateTime(2010, 12, 25)
        Return blogEntry
    End Function

    Public Shared Function GetWithDatePublished(ByVal datePublished As DateTime) As BlogEntry
        Dim blogEntry = [Get]()
        blogEntry.DatePublished = datePublished
        Return blogEntry
    End Function

    Public Shared Function GetWithTitle(ByVal title As String) As BlogEntry
        Dim blogEntry = [Get]()
        blogEntry.Title = title
        Return blogEntry
    End Function


    Public Shared Function GetWithName(ByVal name As String) As BlogEntry
        Dim blogEntry = [Get]()
        blogEntry.Name = name
        Return blogEntry
    End Function


    Public Shared Function GetWithText(ByVal text As String) As BlogEntry
        Dim blogEntry = [Get]()
        blogEntry.Text = text
        Return blogEntry
    End Function


End Class
