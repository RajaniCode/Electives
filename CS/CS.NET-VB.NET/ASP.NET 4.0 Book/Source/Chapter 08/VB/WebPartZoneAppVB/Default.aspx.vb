
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim wpm As New WebPartManager
        Dim wpz As New WebPartZone
        Dim str As String
        wpz.MenuLabelText = TextBox1.Text
        str = wpz.MenuLabelText
        Label3.Text = "Header text:" + str

    End Sub
End Class
