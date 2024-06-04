
Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim str As String = "Welcome  " & DropDownList1.SelectedValue & " " & TextBox1.Text
        Button1.Visible = False
        DropDownList1.Visible = False
        TextBox1.Visible = False
        Label1.Visible = False
        Label2.Visible = False
        Response.Write(str)
    End Sub
End Class
