Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim trans As New TransactionClass()
        Label1.Text = trans.AddDetails("Table Lamp", "A table lamp with the picture of flowers", "Show piece")
    End Sub
End Class
