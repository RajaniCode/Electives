Imports Component
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim com As New Component.Component
        Label1.Text = "The addition of the two numbers is " & com.Add(10, 24)
    End Sub
End Class
