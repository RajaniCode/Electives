Imports Microsoft.VisualBasic.FileIO

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim sourcePath = "C:\Documents and Settings\RAJANI\My Documents\Code\VB.NET\VB2008CopyDirectory\Source"
        Dim destinationPath As String = "C:\Documents and Settings\RAJANI\My Documents\Code\VB.NET\VB2008CopyDirectory\Target"
        FileSystem.CopyDirectory(sourcePath, destinationPath, UIOption.AllDialogs)

    End Sub

End Class
