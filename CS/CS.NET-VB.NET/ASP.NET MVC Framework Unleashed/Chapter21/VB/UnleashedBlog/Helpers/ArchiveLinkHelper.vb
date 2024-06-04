Imports System.Globalization

Namespace Helpers

    Public Module ArchiveLinkHelper

        <System.Runtime.CompilerServices.Extension()> _
        Public Function ArchiveLink(ByVal helper As HtmlHelper, ByVal archiveInfo As ArchiveInfo) As String

            Dim monthName As String = GetMonthName(archiveInfo.Month)
            Dim linkText As String = String.Format("{0}, {1} ({2})", monthName, archiveInfo.Year, archiveInfo.Count)
            Return helper.RouteLink(linkText, "ArchiveYearMonth", New With {Key .year = archiveInfo.Year, Key .month = archiveInfo.Month})
        End Function


        Private Function GetMonthName(ByVal monthNumber As Integer) As String
            Dim dtf As New DateTimeFormatInfo()
            Return dtf.GetMonthName(monthNumber)
        End Function

    End Module

End Namespace
