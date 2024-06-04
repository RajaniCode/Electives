
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim wpm As New WebPartManager
    Dim propgrid As New PropertyGridEditorPart

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label1.Visible = True
        Label2.Visible = True
        Label3.Visible = True
        Label1.Text = propgrid.DisplayTitle
        propgrid.Title = "MY PROPERTY GRID EDITOR PART!!!"
        Label2.Text = propgrid.Title
        propgrid.ToolTip = "MY TOOLTIP"
        Label3.Text = propgrid.ToolTip

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
    End Sub
End Class
