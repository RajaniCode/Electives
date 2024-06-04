Imports System.Web.Profile
Partial Class Manageprofile
    Inherits System.Web.UI.Page
    Protected Sub Page_PreRender()
        Txtnumprofiles.Text =
        ProfileManager.GetNumberOfProfiles(ProfileAuthenticationOption.All).ToString()
    End Sub

    Protected Sub Btndelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btndelete.Click
        Try
            Dim del As Integer = 0


            del = ProfileManager.DeleteInactiveProfiles(ProfileAuthenticationOption.All, DateTime.Now.AddMinutes(-4))
            Label1.Text = String.Format("{0} Profiles deleted ", del)
        Catch ex As Exception
            Label1.Text = ex.Message
        End Try

    End Sub
End Class
