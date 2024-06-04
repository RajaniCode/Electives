
Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim name As String = Nothing
            Response.Write(name.ToString())
        Catch ex As Exception
            Label1.Visible = True
            Label1.Text = "The Error Message is:  " & ex.Message
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Visible = False
    End Sub

End Class
