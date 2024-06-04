Namespace Helpers

    Public Module BlogLinkHelper

        <System.Runtime.CompilerServices.Extension()> _
        Public Function BlogLink(ByVal helper As HtmlHelper, ByVal entry As BlogEntry) As String
            Return helper.ActionLink(entry.Title, "Index", "Archive", New With {Key .year = entry.DatePublished.Year, Key .month = entry.DatePublished.Month, Key .day = entry.DatePublished.Day, Key .name = entry.Name}, Nothing)
        End Function

    End Module

End Namespace

