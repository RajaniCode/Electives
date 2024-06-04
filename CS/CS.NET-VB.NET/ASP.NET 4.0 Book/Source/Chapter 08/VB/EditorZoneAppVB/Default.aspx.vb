
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim wpm As New WebPartManager
    Dim ez As New EditorZone


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim str As String
        Dim str1 As String
        str = ez.EmptyZoneText
        Label2.Text = str
        str1 = ez.HeaderText
        Label3.Text = str1

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = WebPartManager.EditDisplayMode.Name
    End Sub
End Class
