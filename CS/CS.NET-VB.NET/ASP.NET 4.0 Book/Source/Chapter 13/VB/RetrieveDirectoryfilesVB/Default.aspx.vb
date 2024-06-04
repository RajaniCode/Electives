Imports System.IO
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Btnshow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnshow.Click
        Dim path As String = TextBox1.Text
        Dim dir As New DirectoryInfo(path)
        If dir.Exists Then
            Dim files() As FileInfo = dir.GetFiles("*")
            For Each file As FileInfo In files
                ListBox1.Items.Add("Name " & file.Name & "  Size: " &
                   file.Length.ToString())
            Next file
            Label2.Text = "Directory Exists"
        Else
            Label2.Text = "Directory at " & path & " Does not exists"
        End If

    End Sub
End Class
