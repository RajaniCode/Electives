
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Label3.Text = ""
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If FileUpload1.HasFile Then
            FileUpload1.SaveAs("D:\" & FileUpload1.FileName)
            Label3.Text = "File " + FileUpload1.FileName + " is Uploaded"
        Else
            Label3.Text = "No uploaded file"
        End If

    End Sub
End Class
