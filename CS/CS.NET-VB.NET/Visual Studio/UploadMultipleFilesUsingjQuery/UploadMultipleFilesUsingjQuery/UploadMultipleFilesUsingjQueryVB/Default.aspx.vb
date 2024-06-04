
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Try
            ' Get the HttpFileCollection
            Dim hfc As HttpFileCollection = Request.Files
            For i As Integer = 0 To hfc.Count - 1
                Dim hpf As HttpPostedFile = hfc(i)
                If hpf.ContentLength > 0 Then
                    hpf.SaveAs(Server.MapPath("MyFiles") & "\" & System.IO.Path.GetFileName(hpf.FileName))
                    Response.Write("<b>File: </b>" & hpf.FileName & "  <b>Size:</b> " & hpf.ContentLength & "  <b>Type:</b> " & hpf.ContentType & " Uploaded Successfully <br/>")
                End If
            Next i
        Catch ex As Exception

        End Try
    End Sub
End Class
