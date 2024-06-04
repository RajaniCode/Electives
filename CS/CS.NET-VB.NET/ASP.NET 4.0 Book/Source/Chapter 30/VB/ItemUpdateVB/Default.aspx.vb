
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub DetailsView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewUpdateEventArgs) Handles DetailsView1.ItemUpdating
        Dim updatesuser As MembershipUser = Membership.GetUser()
        updatesuser.Email = CStr(e.NewValues(0))
        updatesuser.Comment = CStr(e.NewValues(1))
        Membership.UpdateUser(updatesuser)
        e.Cancel = True
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        FormsAuthentication.SignOut()
        Response.Redirect("login.aspx")
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Membership.DeleteUser(User.Identity.Name)
        FormsAuthentication.SignOut()
        Response.Redirect("login.aspx")
    End Sub
End Class
