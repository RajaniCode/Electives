Imports System.IO
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Btnfile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnfile.Click
        Dim fs As FileStream
        Try
            fs = File.Open(TextBox1.Text, FileMode.Open)
            Dim sw As New StreamWriter(fs)
            If File.Exists(TextBox1.Text) Then
                Label1.Text = "File is opened"
                sw.WriteLine(TextBox2.Text)
                sw.Close()
                Lbldisplay.Text = "File is saved at" & TextBox1.Text & "  and data is replaced with the new data"
            End If
        Catch ex As Exception
            Lbldisplay.Text = ex.Message
        End Try
    End Sub
   
End Class
