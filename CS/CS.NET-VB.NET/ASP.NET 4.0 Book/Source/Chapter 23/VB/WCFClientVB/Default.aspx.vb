
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Client As New MyServiceClient()
        Label1.Text = Client.MyTask1(TextBox1.Text)
        Client.Close()
    End Sub
End Class
