
Namespace Helpers

    Public Module NameLinkHelper

        <System.Runtime.CompilerServices.Extension()> _
        Public Function NameLink(ByVal helper As HtmlHelper, ByVal comment As Comment) As String
            If Not String.IsNullOrEmpty(comment.Url) Then
                Dim tb = New TagBuilder("a")
                tb.SetInnerText(comment.Name)
                tb.MergeAttribute("href", comment.Url)
                Return tb.ToString(TagRenderMode.Normal)
            End If
            Return helper.Encode(comment.Name)
        End Function

    End Module

End Namespace
