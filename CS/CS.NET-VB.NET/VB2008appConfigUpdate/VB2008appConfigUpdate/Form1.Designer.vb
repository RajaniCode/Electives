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
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDBPwd = New System.Windows.Forms.TextBox
        Me.txtDBUserID = New System.Windows.Forms.TextBox
        Me.txtDBName = New System.Windows.Forms.TextBox
        Me.txtServerName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnChange = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(68, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(312, 20)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Update app.Config File Configuration "
        '
        'txtDBPwd
        '
        Me.txtDBPwd.Location = New System.Drawing.Point(204, 231)
        Me.txtDBPwd.Name = "txtDBPwd"
        Me.txtDBPwd.Size = New System.Drawing.Size(100, 20)
        Me.txtDBPwd.TabIndex = 20
        '
        'txtDBUserID
        '
        Me.txtDBUserID.Location = New System.Drawing.Point(204, 201)
        Me.txtDBUserID.Name = "txtDBUserID"
        Me.txtDBUserID.Size = New System.Drawing.Size(100, 20)
        Me.txtDBUserID.TabIndex = 19
        '
        'txtDBName
        '
        Me.txtDBName.Location = New System.Drawing.Point(204, 173)
        Me.txtDBName.Name = "txtDBName"
        Me.txtDBName.Size = New System.Drawing.Size(100, 20)
        Me.txtDBName.TabIndex = 18
        '
        'txtServerName
        '
        Me.txtServerName.Location = New System.Drawing.Point(204, 144)
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.Size = New System.Drawing.Size(100, 20)
        Me.txtServerName.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(92, 234)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "DB Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(93, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "DB UserID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(92, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Database Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(92, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "SQL Server Name"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(267, 289)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(117, 23)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(95, 289)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(166, 23)
        Me.btnChange.TabIndex = 11
        Me.btnChange.Text = "Change App.Config Settings"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 404)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDBPwd)
        Me.Controls.Add(Me.txtDBUserID)
        Me.Controls.Add(Me.txtDBName)
        Me.Controls.Add(Me.txtServerName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnChange)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDBPwd As System.Windows.Forms.TextBox
    Friend WithEvents txtDBUserID As System.Windows.Forms.TextBox
    Friend WithEvents txtDBName As System.Windows.Forms.TextBox
    Friend WithEvents txtServerName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnChange As System.Windows.Forms.Button

End Class
