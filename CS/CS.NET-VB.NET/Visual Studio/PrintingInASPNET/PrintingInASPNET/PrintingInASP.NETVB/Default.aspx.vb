
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Session("ctrl") = Panel1
        ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>")
    End Sub
End Class
