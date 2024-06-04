
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub BulletedList1_Click(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.BulletedListEventArgs) Handles BulletedList1.Click
        Image1.Visible = True
        If e.Index = 1 Then
            Image1.ImageUrl = "Abraham.jpg"
        End If
        If e.Index = 2 Then
            Image1.ImageUrl = "Reginald.jpg"
        End If

    End Sub
End Class
