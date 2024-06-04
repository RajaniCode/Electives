
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Calendar1.SelectedDate = DateAndTime.Now
        TextBox1.Text = "Today's date and time is : " & Calendar1.SelectedDate
    End Sub
End Class
