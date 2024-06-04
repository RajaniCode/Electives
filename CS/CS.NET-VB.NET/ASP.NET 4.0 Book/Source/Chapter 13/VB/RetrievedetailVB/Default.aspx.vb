Imports System.IO
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Btnshow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnshow.Click

        Dim str As String
        Dim l As String
        Dim attr As String = ""
        Try
            str = TextBox1.Text
            l = File.GetAttributes(str)
            If l = "32" Then
                attr = "Archive"
            End If
            If l = "16" Then
                attr = "Directory"
            End If
            TextBox2.Text = " File Attributes :  " & attr & "  Created at: " & File.GetCreationTime(str).ToString() & " Last Accessed at :" & File.GetLastAccessTime(str)
        Catch ex As Exception
            TextBox2.Text = ex.Message
        End Try

    End Sub
End Class
