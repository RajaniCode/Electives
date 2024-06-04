Imports System.IO
Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub BtnCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        Dim path As String
        Dim sw As StreamWriter
        Try
            path = TextBox1.Text
            If (Not File.Exists(path)) Then
                sw = File.CreateText(path)
                sw.WriteLine(TextBox2.Text)
                sw.Close()
                Label2.Text = "File Created"
                Exit Sub
            Else
                Label2.Text = " The File already Exists at this location..Please change the file name"
            End If
        Catch ex As Exception
            TextBox2.Text = ex.Message
        End Try

    End Sub
End Class
