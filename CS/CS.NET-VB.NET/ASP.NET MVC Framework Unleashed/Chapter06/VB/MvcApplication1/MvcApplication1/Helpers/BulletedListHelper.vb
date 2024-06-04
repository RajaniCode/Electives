Imports System.IO

Public Module BulletedListHelper

    <System.Runtime.CompilerServices.Extension()> _
    Function BulletedList(ByVal helper As HtmlHelper, ByVal name As String) As String
        Dim items As IEnumerable = helper.ViewData.Eval(name)
        If items Is Nothing Then
            Throw New NullReferenceException("Cannot find " & name & " in view data")
        End If

        Dim writer = New HtmlTextWriter(New StringWriter())

        ' Open UL
        writer.RenderBeginTag(HtmlTextWriterTag.Ul)
        For Each item In items
            writer.RenderBeginTag(HtmlTextWriterTag.Li)
            writer.Write(helper.Encode(item))
            writer.RenderEndTag()
            writer.WriteLine()
        Next item
        ' Close UL
        writer.RenderEndTag()

        ' Return the HTML string
        Return writer.InnerWriter.ToString()
    End Function

End Module
