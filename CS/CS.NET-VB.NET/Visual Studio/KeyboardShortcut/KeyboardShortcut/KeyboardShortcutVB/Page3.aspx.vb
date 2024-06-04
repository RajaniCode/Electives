
Partial Class Page3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "Home", "document.attachEvent ('onkeyup', HomeKey);", True)
    End Sub
End Class
