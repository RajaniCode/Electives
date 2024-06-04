
Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Calendar1 As Calendar
        Dim TextBox1 As TextBox
        Calendar1 = CType(PreviousPage.FindControl("Calendar1"), Calendar)
        TextBox1 = CType(PreviousPage.FindControl("TextBox1"), TextBox)
        Label1.Text = "Hi " + TextBox1.Text + ", here is the output of the Cross Page Post Back Button: " + Calendar1.SelectedDate.ToString()
    End Sub
End Class
