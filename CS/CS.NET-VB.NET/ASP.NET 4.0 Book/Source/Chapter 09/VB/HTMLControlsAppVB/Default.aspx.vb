
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Select1_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles Select1.ServerChange
        span1.InnerHtml = "You have selected " & Select1.Value.ToString & " color in dropdown list."
    End Sub

    Protected Sub Checkbox1_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles Checkbox1.ServerChange
        If Checkbox1.Checked = True Then
            span1.InnerHtml = "CheckBox is checked"
        Else
            span1.InnerHtml = "CheckBox is unchecked"
        End If
    End Sub

    Protected Sub Radio1_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles Radio1.ServerChange
        If Radio1.Checked = True Then
            span1.InnerHtml = "Radio button is selected"
        Else
            span1.InnerHtml = "Radio button is not selected"
        End If
    End Sub

    Protected Sub TextArea1_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextArea1.ServerChange
        If TextArea1.Value = "" Then
            span1.InnerHtml = "TextArea is empty"
        Else
            span1.InnerHtml = "There is some text in TextArea"

        End If
    End Sub

    Protected Sub Select2_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles Select2.ServerChange
        Dim loopindex As Integer
        span1.InnerHtml = "You have selected "
        For loopindex = 0 To Select2.Items.Count - 1
            If Select2.Items(loopindex).Selected Then
                span1.InnerHtml &= Select2.Items(loopindex).Value.ToString & " "
            End If
        Next
    End Sub

    Protected Sub Button1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.ServerClick
        span2.InnerHtml = "Submit button is clicked."
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextArea1.Attributes("onblur") = "javascript:alert('TextArea lost the focus');"
    End Sub

    Protected Sub Button2_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.ServerClick
        Checkbox1.Checked = False
        Radio1.Checked = False
        TextArea1.Value = Nothing
        Select1.SelectedIndex = 0
        Select2.SelectedIndex = 0
    End Sub
End Class

