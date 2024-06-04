Imports System.Drawing
Imports System.Drawing.Imaging

Public Class Form1

    Private Sub GrabScreenshotToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrabScreenshotToolStripMenuItem.Click
        Dim bmpSS As Bitmap
        Dim gfxSS As Graphics

        bmpSS = New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb)
        gfxSS = Graphics.FromImage(bmpSS)
        gfxSS.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy)

        Dim saveDialog As New SaveFileDialog
        saveDialog.Filter = "JPeg Image|*.jpg"
        saveDialog.Title = "Save Image as"
        saveDialog.ShowDialog()
        If saveDialog.FileName <> "" Then
            bmpSS.Save(saveDialog.FileName, ImageFormat.Jpeg)
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ShowInTaskbar = False
        Me.WindowState = FormWindowState.Minimized
        Me.Hide()
    End Sub
End Class
