
Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Submit1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Submit1.ServerClick
        If FileName.Value = "" Or File1.Value.ToString = "" Then
            messagearea.InnerHtml = "Error: You must enter a file name."
            Return
        End If
        If File1.PostedFile.ContentLength > 0 Then
            Try
                File1.PostedFile.SaveAs(("C:\" & FileName.Value))
                messagearea.InnerHtml = "File uploaded successfully."
            Catch ex As Exception
                messagearea.InnerHtml = "Error saving file."
            End Try
        End If
    End Sub
End Class

