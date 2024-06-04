
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "Shortcut", "document.attachEvent ('onkeyup',ShortcutKeys);", True)
    End Sub
End Class
