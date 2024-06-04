
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If NoBot1.IsValid() Then
            Label3.Text = "User appears as a bot"
        Else
            Label3.Text = "User appears as a Nobot"
        End If
    End Sub
    Protected Sub generatechallenge(ByVal sender As Object, ByVal e As AjaxControlToolkit.NoBotEventArgs)
        Dim sec As New Random()
        Dim first As Integer = sec.[Next](60)
        Dim second As Integer = sec.[Next](60)
        Dim third As Integer = sec.[Next](60)
        e.ChallengeScript = [String].Format("eval('{0}+{1}+{2}')", first, second, third)
        e.RequiredResponse = Convert.ToString(first + second + third)
    End Sub

End Class
