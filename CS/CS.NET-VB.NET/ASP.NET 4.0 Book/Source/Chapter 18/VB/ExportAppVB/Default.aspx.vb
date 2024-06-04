
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.InitComplete
        If WebPartManager1.Personalization.CanEnterSharedScope Then
            If WebPartManager1.Personalization.Scope = PersonalizationScope.User Then

                RadioButton1.Checked = True
            Else
                RadioButton2.Checked = True
            End If

        End If
    End Sub

    Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        AddHandler Page.InitComplete, AddressOf Page_InitComplete
    End Sub
    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        WebPartManager1.DisplayMode = WebPartManager.BrowseDisplayMode
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        WebPartManager1.DisplayMode = WebPartManager.EditDisplayMode
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        WebPartManager1.Personalization.ResetPersonalizationState()
    End Sub
    Protected Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

        If WebPartManager1.Personalization.Scope = PersonalizationScope.Shared Then
            WebPartManager1.Personalization.ToggleScope()
        End If
    End Sub
    Protected Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If WebPartManager1.Personalization.CanEnterSharedScope AndAlso _
         WebPartManager1.Personalization.Scope = PersonalizationScope.User Then
            WebPartManager1.Personalization.ToggleScope()
        End If
    End Sub

End Class
