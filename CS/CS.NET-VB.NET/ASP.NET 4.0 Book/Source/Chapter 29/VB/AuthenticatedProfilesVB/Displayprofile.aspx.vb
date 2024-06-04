
Partial Class Displayprofile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Country.Text = Profile.Country
        Gender.Text = Profile.Gender
        Name.Text = Profile.Name

    End Sub
End Class
