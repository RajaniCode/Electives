Imports System.IO
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub BtnCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        Dim directorypath As String = TextBox1.Text
        Dim subdir As System.IO.DirectoryInfo = New DirectoryInfo(TextBox1.Text)
        Try
            Dim subname As String = TextBox2.Text
            subdir.CreateSubdirectory(subname)
            Label2.Text = "Subdirectory: " & subname & " is created at " & directorypath
        Catch ex As Exception
            Label2.Text = ex.Message
        End Try

    End Sub
End Class
