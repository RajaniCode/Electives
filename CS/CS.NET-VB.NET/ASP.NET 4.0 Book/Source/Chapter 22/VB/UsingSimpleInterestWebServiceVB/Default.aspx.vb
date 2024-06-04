
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Dim wr As New SimpleInterestWebReference.SimpleInterest()
        Dim ws As New localhost.WebService()
        Dim SI As Double
        If txtPrincipal.Text = Nothing Or txtRate.Text = Nothing Or txtDuration.Text =
         Nothing Then
            Label5.Text = "Unable to calculate simple interest"
        Else
            SI = ws.CalculateSimpleInterest(CDbl(txtPrincipal.Text),
             CDbl(txtRate.Text), CInt(txtDuration.Text))
            txtSimpleInterest.Enabled = True
            txtSimpleInterest.Text = SI.ToString()
            Label5.Text = ""
        End If

    End Sub
End Class
