Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Submit1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Submit1.ServerClick
        span1.InnerHtml = "Selected Day: " & Select1.Value.ToString
        Dim loopindex As Integer
        span2.InnerHtml = "Selected month: "
        For loopindex = 0 To Select2.Items.Count - 1
            If Select2.Items(loopindex).Selected Then
                span2.InnerHtml &= Select2.Items(loopindex).Value.ToString & " "
            End If
        Next
    End Sub
End Class
