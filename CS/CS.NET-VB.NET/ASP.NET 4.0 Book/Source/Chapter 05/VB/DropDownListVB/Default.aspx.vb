
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Label4.Text = "You have selected: " + DropDownList1.SelectedItem.Text
    End Sub
End Class
