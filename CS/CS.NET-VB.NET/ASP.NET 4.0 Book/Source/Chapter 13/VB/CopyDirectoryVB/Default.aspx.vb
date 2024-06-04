Imports System.IO
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub BtnCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCopy.Click
        Try
            Dim SDir As New DirectoryInfo(TextBox1.Text)
            Dim DDir As New DirectoryInfo(TextBox2.Text)
            CpyDir(SDir, DDir)
            Label2.Text = "Directoy is copied "
        Catch ex As Exception
            Label2.Text = ex.Message
        End Try

    End Sub
    Shared Sub CpyDir(ByVal src As DirectoryInfo, ByVal destin As DirectoryInfo)
        If (Not destin.Exists) Then
            destin.Create()
            ' To Copy all files
            Dim files() As FileInfo = src.GetFiles()
            For Each file As FileInfo In files
                file.CopyTo(Path.Combine(destin.FullName, file.Name))
            Next file
            ' Process subdirectories.
            Dim dirs() As DirectoryInfo = src.GetDirectories()
            For Each dir As DirectoryInfo In dirs
                Dim destinationDir As String = Path.Combine(destin.FullName, dir.Name)
                CpyDir(dir, New DirectoryInfo(destinationDir))
            Next dir
        End If
    End Sub

End Class
