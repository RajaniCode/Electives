
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim service As New localhost.CachedWebServiceVB()

        Dim num1 As Integer = Convert.ToInt16(TextBox1.Text)
        Dim num2 As Integer = Convert.ToInt16(TextBox2.Text)
        Label1.Text = service.GetCacheResult(num1, num2)

    End Sub
End Class
