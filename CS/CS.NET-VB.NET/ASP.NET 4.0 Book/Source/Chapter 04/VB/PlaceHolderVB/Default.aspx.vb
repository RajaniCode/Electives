
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim Textbox1 As New System.Web.UI.WebControls.TextBox

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Textbox1.Text = "This is TextBox inside the placeHolder"
        Textbox1.Style("width") = "280PX"
        PlaceHolder1.Controls.Add(Textbox1)
    End Sub
End Class
