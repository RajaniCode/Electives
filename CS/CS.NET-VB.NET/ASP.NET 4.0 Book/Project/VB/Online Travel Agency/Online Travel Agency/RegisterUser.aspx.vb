Public Class WebForm8
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub CreateUserWizard1_CreatedUser(ByVal sender As Object, ByVal e As EventArgs) Handles CreateUserWizard1.CreatedUser
        Dim UserNameTextBox As TextBox = CType(CreateUserWizardStep1.ContentTemplateContainer.FindControl("UserName"), TextBox)
        Dim DataSource As SqlDataSource = CType(CreateUserWizardStep1.ContentTemplateContainer.FindControl("InsertExtraInfo"), SqlDataSource)

        Dim User As MembershipUser = Membership.GetUser(UserNameTextBox.Text)
        Dim UserGUID As Object = User.ProviderUserKey

        DataSource.InsertParameters.Add("UserId", UserGUID.ToString())
        DataSource.Insert()
    End Sub
End Class