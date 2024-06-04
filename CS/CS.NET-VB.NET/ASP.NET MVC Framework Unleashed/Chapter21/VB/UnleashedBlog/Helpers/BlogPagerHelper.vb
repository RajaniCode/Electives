
Namespace Helpers
    Public Module BlogPagerHelper

        <System.Runtime.CompilerServices.Extension()> _
        Public Function BlogPager(ByVal helper As HtmlHelper, ByVal pager As IPagedList) As String
            ' Don't display anything if not multiple pages
            If pager.TotalPageCount = 1 Then
                Return String.Empty
            End If

            ' Build route data
            Dim routeData = New RouteValueDictionary(helper.ViewContext.RouteData.Values)

            ' Build string
            Dim sb = New StringBuilder()

            ' Render Newer Entries
            If pager.PageIndex > 0 Then
                routeData("page") = pager.PageIndex - 1
                sb.Append(helper.ActionLink("Newer Entries", "Index", routeData))
            End If

            ' Render divider
            If pager.PageIndex > 0 AndAlso pager.PageIndex < pager.TotalPageCount - 1 Then
                sb.Append(" | ")
            End If

            ' Render Older Entries
            If pager.PageIndex < pager.TotalPageCount - 1 Then
                routeData("page") = pager.PageIndex + 1
                sb.Append(helper.ActionLink("Older Entries", "Index", routeData))
            End If

            Return sb.ToString()
        End Function


        <System.Runtime.CompilerServices.Extension()> _
        Public Function BlogPager(ByVal helper As AjaxHelper, ByVal pager As IPagedList) As String
            ' Don't display anything if not multiple pages or no more entries
            If pager.TotalPageCount = 1 OrElse pager.PageIndex = pager.TotalPageCount - 1 Then
                Return String.Empty
            End If

            ' Build route data
            Dim routeData = New RouteValueDictionary(helper.ViewContext.RouteData.Values)

            ' Build Ajax options
            Dim options = New AjaxOptions With {.UpdateTargetId = "blogEntries", .InsertionMode = InsertionMode.InsertAfter, .LoadingElementId = "loadingMoreEntries", .OnBegin = "function() {this.style.display='none';}"}

            ' Render More Entries
            routeData("page") = pager.PageIndex + 1
            Return helper.ActionLink("More Entries", "Index", routeData, options)
        End Function




    End Module
End Namespace
