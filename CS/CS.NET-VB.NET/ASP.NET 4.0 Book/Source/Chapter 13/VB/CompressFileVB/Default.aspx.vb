Imports System.IO
Imports System.IO.Compression
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Btncompress_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btncompress.Click
        Dim path As String = Txtsrc.Text
        Dim sourceFile As FileStream
        Dim destinationfile As FileStream
        Dim zip As GZipStream = Nothing
        Try
            sourceFile = File.OpenRead(path)
            destinationfile = File.Create(Txtdestination.Text & ".gzip")
            Dim buffer(sourceFile.Length - 1) As Byte
            sourceFile.Read(buffer, 0, buffer.Length)
            zip = New GZipStream(destinationfile, CompressionMode.Compress)
            zip.Write(buffer, 0, buffer.Length)
            zip.Close()
            sourceFile.Close()
            destinationfile.Close()
            lbldisplay.Text = "File is compressed and located at " & Txtdestination.Text
        Catch ex As Exception
            lbldisplay.Text = ex.Message
        End Try



    End Sub
End Class
