Imports System.Security.Principal
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub createbutton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles createbutton.Click
        Dim status As MembershipCreateStatus
        Membership.CreateUser(myUserId.Text, myPassword.Text, myEmail.Text, dropdownlist1.SelectedValue, myPasswordAnswer.Text, True, status)
        Select Case status
            Case (MembershipCreateStatus.Success)
                myUserId.Text = Nothing
                myPassword.Text = Nothing
                myEmail.Text = Nothing
                dropdownlist1.SelectedIndex = -1
                myPasswordAnswer.Text = Nothing
                lblresults.Text = "User successfully created!"
                lblresults.Visible = True
                Exit Sub
            Case (MembershipCreateStatus.DuplicateUserName)
                lblresults.Text = "User already exist"
                lblresults.Visible = True
                Exit Sub
            Case Else
                lblresults.Text = "error creating users"
                lblresults.Visible = True
                Exit Sub
        End Select
    End Sub
End Class
