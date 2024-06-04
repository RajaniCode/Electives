
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Panel2.BackColor = Drawing.Color.Red
    End Sub

    Protected Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Panel2.BackColor = Drawing.Color.Green
    End Sub

    Protected Sub RadioButton3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        Panel2.BackColor = Drawing.Color.Yellow
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Panel1.Visible = True
    End Sub
End Class
