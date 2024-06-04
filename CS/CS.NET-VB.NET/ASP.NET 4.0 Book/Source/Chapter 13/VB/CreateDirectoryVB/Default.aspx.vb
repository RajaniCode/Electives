Imports System.IO
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub BtnCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        Dim path As String = TextBox1.Text
        Label2.Text = ""
        Try
            If (Not Directory.Exists(path)) Then
                Directory.CreateDirectory(path)
                Label2.Text = "Directory is Created...." & path
            Else
                If Directory.Exists(path) Then
                    Label2.Text = " Directory Is already Created at " & path
                End If
            End If
        Catch ex As Exception
            Label2.Text = "Please Check The Path and Name of Directory, " &
               ex.Message
        End Try

    End Sub
End Class
