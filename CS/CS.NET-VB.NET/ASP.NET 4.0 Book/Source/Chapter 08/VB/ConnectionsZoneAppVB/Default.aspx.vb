
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim wpm As New WebPartManager
    Dim conn As New ConnectionsZone

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim value As String
        value = conn.NoExistingConnectionInstructionText
        conn.NoExistingConnectionInstructionText = value
        Label3.Text = conn.NoExistingConnectionInstructionText
        Label4.Text = "DEFAULT:" & conn.ConfigureConnectionTitle
        conn.ConfigureConnectionTitle = _
        "Configure a new connection"
        Label6.Text = "CUSTOM:" & conn.ConfigureConnectionTitle
    End Sub
End Class
