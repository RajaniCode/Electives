Imports System.IO
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub BtnRename_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRename.Click
        Dim strsorc As String = TextBox1.Text
        Dim strdest As String = TextBox2.Text
        Try
            Dim sourcefile As New FileInfo(strsorc)
            If sourcefile.Exists Then
                sourcefile.MoveTo(strdest)
                Label3.Text = " File is renamed"
            Else
                Label3.Text = "file not found"
            End If
        Catch ex As Exception
            Label3.Text = ex.Message
        End Try

    End Sub
End Class
