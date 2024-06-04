<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.RTWeatherType = New System.Windows.Forms.RichTextBox
        Me.weatherImage = New System.Windows.Forms.PictureBox
        Me.RTTemp = New System.Windows.Forms.RichTextBox
        Me.groupBox1.SuspendLayout()
        CType(Me.weatherImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.RTWeatherType)
        Me.groupBox1.Controls.Add(Me.weatherImage)
        Me.groupBox1.Controls.Add(Me.RTTemp)
        Me.groupBox1.Location = New System.Drawing.Point(3, -3)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(162, 80)
        Me.groupBox1.TabIndex = 10
        Me.groupBox1.TabStop = False
        '
        'RTWeatherType
        '
        Me.RTWeatherType.BackColor = System.Drawing.SystemColors.Control
        Me.RTWeatherType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RTWeatherType.Enabled = False
        Me.RTWeatherType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RTWeatherType.ForeColor = System.Drawing.Color.Teal
        Me.RTWeatherType.Location = New System.Drawing.Point(64, 49)
        Me.RTWeatherType.Name = "RTWeatherType"
        Me.RTWeatherType.Size = New System.Drawing.Size(92, 23)
        Me.RTWeatherType.TabIndex = 9
        Me.RTWeatherType.Text = ""
        '
        'weatherImage
        '
        Me.weatherImage.Location = New System.Drawing.Point(6, 20)
        Me.weatherImage.Name = "weatherImage"
        Me.weatherImage.Size = New System.Drawing.Size(52, 52)
        Me.weatherImage.TabIndex = 0
        Me.weatherImage.TabStop = False
        '
        'RTTemp
        '
        Me.RTTemp.BackColor = System.Drawing.SystemColors.Control
        Me.RTTemp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RTTemp.Enabled = False
        Me.RTTemp.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RTTemp.ForeColor = System.Drawing.Color.Teal
        Me.RTTemp.Location = New System.Drawing.Point(64, 24)
        Me.RTTemp.Name = "RTTemp"
        Me.RTTemp.Size = New System.Drawing.Size(65, 23)
        Me.RTTemp.TabIndex = 8
        Me.RTTemp.Text = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(168, 80)
        Me.Controls.Add(Me.groupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.groupBox1.ResumeLayout(False)
        CType(Me.weatherImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents RTWeatherType As System.Windows.Forms.RichTextBox
    Private WithEvents weatherImage As System.Windows.Forms.PictureBox
    Private WithEvents RTTemp As System.Windows.Forms.RichTextBox

End Class
