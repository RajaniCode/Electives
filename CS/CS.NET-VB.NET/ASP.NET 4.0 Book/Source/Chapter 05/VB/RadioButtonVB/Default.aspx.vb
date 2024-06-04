
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Label3.Text = "<font color=black>You have selected: </font>" + RadioButton1.Text
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False

    End Sub

    Protected Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Label3.Text = "<font color=black>You have selected: </font>" + RadioButton2.Text
        RadioButton1.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False

    End Sub

    Protected Sub RadioButton3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        Label3.Text = "<font color=black>You have selected: </font>" + RadioButton3.Text
        RadioButton2.Checked = False
        RadioButton1.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False

    End Sub

    Protected Sub RadioButton4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        Label3.Text = "<font color=black>You have selected: </font>" + RadioButton4.Text
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton1.Checked = False
        RadioButton5.Checked = False

    End Sub

    Protected Sub RadioButton5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        Label3.Text = "<font color=black>You have selected: </font>" + RadioButton5.Text
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton1.Checked = False

    End Sub
End Class
