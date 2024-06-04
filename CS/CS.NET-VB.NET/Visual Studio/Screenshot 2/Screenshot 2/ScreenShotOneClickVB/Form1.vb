Imports System.Drawing
Imports System.Drawing.Imaging

Public Class Form1

    Dim bmp As Bitmap
    Dim graphics As Graphics

    Private Sub GrabScreenshotToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrabScreenshotToolStripMenuItem.Click
        Try
            bmp = New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb)
            graphics = graphics.FromImage(bmp)
            graphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy)

            Dim saveDialog As New SaveFileDialog
            saveDialog.Filter = "JPeg Image|*.jpg"
            saveDialog.Title = "Save Image as"
            saveDialog.ShowDialog()
            If saveDialog.FileName <> "" Then
                bmp.Save(saveDialog.FileName, ImageFormat.Jpeg)
            End If

        Catch ex As Exception

        Finally
            bmp = Nothing
            graphics = Nothing
        End Try

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ShowInTaskbar = False
        Me.WindowState = FormWindowState.Minimized
        Me.Hide()
    End Sub

    Private Sub SelectAreaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAreaToolStripMenuItem.Click
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.DoubleClick
        Try
            bmp = New Bitmap(Me.Size.Width, Me.Size.Height, PixelFormat.Format32bppArgb)


            graphics = Graphics.FromImage(bmp)
            graphics.CopyFromScreen(Me.Location.X, Me.Location.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy)

            Dim saveDialog As New SaveFileDialog
            saveDialog.Filter = "JPeg Image|*.jpg"
            saveDialog.Title = "Save Image as"
            saveDialog.ShowDialog()
            If saveDialog.FileName <> "" Then
                bmp.Save(saveDialog.FileName, ImageFormat.Jpeg)
            End If
            bmp.Dispose()
            graphics.Dispose()

            Me.Hide()
            Me.WindowState = FormWindowState.Minimized
        Catch ex As Exception

        Finally
            bmp = Nothing
            graphics = Nothing
        End Try

    End Sub
End Class
