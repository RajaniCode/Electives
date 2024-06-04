
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim cal As Calendar
            cal = CType(Master.FindControl("Calendar1"), Calendar)
            If Not cal Is Nothing Then
                cal.VisibleDate = TextBox1.Text
                cal.SelectedDate = TextBox1.Text
                Label1.Text = "You have entered " + TextBox1.Text
                Label1.Visible = True
            End If
        Catch
            Label1.Text = "Wrong Format Entered"
            Label1.Visible = True
        End Try
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Visible = False
    End Sub
End Class
