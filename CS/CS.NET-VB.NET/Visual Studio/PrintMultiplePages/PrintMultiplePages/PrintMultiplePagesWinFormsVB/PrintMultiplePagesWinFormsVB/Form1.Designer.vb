<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtFileNm = New System.Windows.Forms.TextBox
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SuspendLayout()
        '
        'txtFileNm
        '
        Me.txtFileNm.Location = New System.Drawing.Point(25, 84)
        Me.txtFileNm.Name = "txtFileNm"
        Me.txtFileNm.Size = New System.Drawing.Size(147, 20)
        Me.txtFileNm.TabIndex = 0
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(188, 82)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "Browse..."
        Me.btnBrowse.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(188, 185)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 2
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'openFileDialog1
        '
        Me.openFileDialog1.FileName = "openFileDialog1"
        Me.openFileDialog1.Filter = "txt files (*.txt)|*.txt"
        Me.openFileDialog1.FilterIndex = 2
        Me.openFileDialog1.InitialDirectory = "C:\"
        Me.openFileDialog1.Title = "Select a File to be printed"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 264)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtFileNm)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFileNm As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
