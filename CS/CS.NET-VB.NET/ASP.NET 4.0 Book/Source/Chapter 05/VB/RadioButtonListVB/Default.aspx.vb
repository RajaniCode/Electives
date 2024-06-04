
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Label3.Text = "<font color=black>Your selected category is: </font> " +
    RadioButtonList1.SelectedItem.Value.ToString()
    End Sub
End Class
