Imports System.IO

Public Class SimpleView
    Implements IView

    Private _viewPhysicalPath As String

    Public Sub New(ByVal viewPhysicalPath As String)
        _viewPhysicalPath = viewPhysicalPath
    End Sub

#Region "IView Members"

	Public Sub Render(ByVal viewContext As ViewContext, ByVal writer As TextWriter) Implements IView.Render
        ' Load file
        Dim rawContents As String = File.ReadAllText(_viewPhysicalPath)

        ' Perform replacements
        Dim parsedContents As String = Parse(rawContents, viewContext.ViewData)

        ' Write results to HttpContext
        writer.Write(parsedContents)
    End Sub

#End Region

    Public Function Parse(ByVal contents As String, ByVal viewData As ViewDataDictionary) As String
        Return Regex.Replace(contents, "\{(.+)\}", Function(m) GetMatch(m, viewData))
    End Function

    Protected Overridable Function GetMatch(ByVal m As Match, ByVal viewData As ViewDataDictionary) As String
        If m.Success Then
            Dim key As String = m.Result("$1")
            If viewData.ContainsKey(key) Then
                Return viewData(key).ToString()
            End If
        End If
        Return String.Empty
    End Function

End Class
