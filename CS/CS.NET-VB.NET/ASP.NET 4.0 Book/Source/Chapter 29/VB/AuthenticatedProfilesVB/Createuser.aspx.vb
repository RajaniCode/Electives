
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub CreateUserWizard1_CreatedUser(ByVal sender As Object, ByVal e As System.EventArgs) Handles CreateUserWizard1.CreatedUser
        Try
            Dim pc As ProfileCommon = CType(ProfileCommon.Create(CreateUserWizard1.UserName, True), ProfileCommon)
            pc.Country = (CType(CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Country"), DropDownList)).SelectedValue
            pc.Gender = (CType(CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Gender"), DropDownList)).SelectedValue
            pc.Name = ((CType(CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Name"), TextBox)).Text)
            'save profile
            pc.Save()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

    End Sub
End Class
