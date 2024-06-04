Imports System.IO
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub BtnRead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRead.Click
        Try
            Dim filename As String = Server.MapPath(TextBox1.Text)
            Dim reader As StreamReader
            Dim str As String
            reader = File.OpenText(filename)
            str = reader.ReadToEnd()
            TextBox2.Text = str
            reader.Close()
            Label2.Text = "File Found and Read successfully!"
        Catch ex As Exception
            Label2.Text = ex.Message
        End Try

    End Sub

    
    Protected Sub BtnAppend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAppend.Click
        Try
            Dim filename As String = Server.MapPath(TextBox1.Text)
            Dim sw As StreamWriter = File.AppendText(filename)
            sw.Write(TextBox2.Text)
            sw.Close()
            Label2.Text = "Text Appended successfully!"
        Catch ex As Exception
            Label2.Text = ex.Message
        End Try

    End Sub
End Class
