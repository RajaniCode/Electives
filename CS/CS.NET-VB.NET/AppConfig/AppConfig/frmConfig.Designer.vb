<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiq
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.LabelDatabasename = New System.Windows.Forms.Label
        Me.LabelFeedback = New System.Windows.Forms.Label
        Me.ButtonTestConnection = New System.Windows.Forms.Button
        Me.TextBoxDatabasename = New System.Windows.Forms.TextBox
        Me.LabelEnterDatabasename = New System.Windows.Forms.Label
        Me.LabelPassword = New System.Windows.Forms.Label
        Me.TextBoxPassword = New System.Windows.Forms.TextBox
        Me.LabelUsername = New System.Windows.Forms.Label
        Me.TextBoxUsername = New System.Windows.Forms.TextBox
        Me.RadioButtonSQLServerAuthentication = New System.Windows.Forms.RadioButton
        Me.RadioButtonWindowsAuthentication = New System.Windows.Forms.RadioButton
        Me.LabelEnterAuthentication = New System.Windows.Forms.Label
        Me.TextBoxServername = New System.Windows.Forms.TextBox
        Me.LabelServername = New System.Windows.Forms.Label
        Me.LabelEnterServername = New System.Windows.Forms.Label
        Me.LabelSpecify = New System.Windows.Forms.Label
        Me.ButtonCancel = New System.Windows.Forms.Button
        Me.ButtonOK = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(380, 357)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(372, 331)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.LabelDatabasename)
        Me.TabPage2.Controls.Add(Me.LabelFeedback)
        Me.TabPage2.Controls.Add(Me.ButtonTestConnection)
        Me.TabPage2.Controls.Add(Me.TextBoxDatabasename)
        Me.TabPage2.Controls.Add(Me.LabelEnterDatabasename)
        Me.TabPage2.Controls.Add(Me.LabelPassword)
        Me.TabPage2.Controls.Add(Me.TextBoxPassword)
        Me.TabPage2.Controls.Add(Me.LabelUsername)
        Me.TabPage2.Controls.Add(Me.TextBoxUsername)
        Me.TabPage2.Controls.Add(Me.RadioButtonSQLServerAuthentication)
        Me.TabPage2.Controls.Add(Me.RadioButtonWindowsAuthentication)
        Me.TabPage2.Controls.Add(Me.LabelEnterAuthentication)
        Me.TabPage2.Controls.Add(Me.TextBoxServername)
        Me.TabPage2.Controls.Add(Me.LabelServername)
        Me.TabPage2.Controls.Add(Me.LabelEnterServername)
        Me.TabPage2.Controls.Add(Me.LabelSpecify)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(372, 331)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'LabelDatabasename
        '
        Me.LabelDatabasename.AutoSize = True
        Me.LabelDatabasename.Location = New System.Drawing.Point(63, 262)
        Me.LabelDatabasename.Name = "LabelDatabasename"
        Me.LabelDatabasename.Size = New System.Drawing.Size(85, 13)
        Me.LabelDatabasename.TabIndex = 58
        Me.LabelDatabasename.Text = "Database name:"
        '
        'LabelFeedback
        '
        Me.LabelFeedback.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelFeedback.ForeColor = System.Drawing.Color.Navy
        Me.LabelFeedback.Location = New System.Drawing.Point(7, 282)
        Me.LabelFeedback.Name = "LabelFeedback"
        Me.LabelFeedback.Size = New System.Drawing.Size(255, 42)
        Me.LabelFeedback.TabIndex = 56
        Me.LabelFeedback.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonTestConnection
        '
        Me.ButtonTestConnection.Location = New System.Drawing.Point(268, 294)
        Me.ButtonTestConnection.Name = "ButtonTestConnection"
        Me.ButtonTestConnection.Size = New System.Drawing.Size(95, 23)
        Me.ButtonTestConnection.TabIndex = 14
        Me.ButtonTestConnection.Text = "Test Connection"
        Me.ButtonTestConnection.UseVisualStyleBackColor = True
        '
        'TextBoxDatabasename
        '
        Me.TextBoxDatabasename.Location = New System.Drawing.Point(165, 259)
        Me.TextBoxDatabasename.Name = "TextBoxDatabasename"
        Me.TextBoxDatabasename.Size = New System.Drawing.Size(198, 20)
        Me.TextBoxDatabasename.TabIndex = 13
        '
        'LabelEnterDatabasename
        '
        Me.LabelEnterDatabasename.AutoSize = True
        Me.LabelEnterDatabasename.Location = New System.Drawing.Point(25, 239)
        Me.LabelEnterDatabasename.Name = "LabelEnterDatabasename"
        Me.LabelEnterDatabasename.Size = New System.Drawing.Size(123, 13)
        Me.LabelEnterDatabasename.TabIndex = 1
        Me.LabelEnterDatabasename.Text = "3. Enter database name:"
        '
        'LabelPassword
        '
        Me.LabelPassword.AutoSize = True
        Me.LabelPassword.Location = New System.Drawing.Point(63, 207)
        Me.LabelPassword.Name = "LabelPassword"
        Me.LabelPassword.Size = New System.Drawing.Size(56, 13)
        Me.LabelPassword.TabIndex = 12
        Me.LabelPassword.Text = "Password:"
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Location = New System.Drawing.Point(165, 204)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.Size = New System.Drawing.Size(198, 20)
        Me.TextBoxPassword.TabIndex = 11
        Me.TextBoxPassword.UseSystemPasswordChar = True
        '
        'LabelUsername
        '
        Me.LabelUsername.AutoSize = True
        Me.LabelUsername.Location = New System.Drawing.Point(63, 176)
        Me.LabelUsername.Name = "LabelUsername"
        Me.LabelUsername.Size = New System.Drawing.Size(61, 13)
        Me.LabelUsername.TabIndex = 10
        Me.LabelUsername.Text = "User name:"
        '
        'TextBoxUsername
        '
        Me.TextBoxUsername.Location = New System.Drawing.Point(165, 173)
        Me.TextBoxUsername.Name = "TextBoxUsername"
        Me.TextBoxUsername.Size = New System.Drawing.Size(198, 20)
        Me.TextBoxUsername.TabIndex = 9
        '
        'RadioButtonSQLServerAuthentication
        '
        Me.RadioButtonSQLServerAuthentication.AutoSize = True
        Me.RadioButtonSQLServerAuthentication.Location = New System.Drawing.Point(66, 142)
        Me.RadioButtonSQLServerAuthentication.Name = "RadioButtonSQLServerAuthentication"
        Me.RadioButtonSQLServerAuthentication.Size = New System.Drawing.Size(151, 17)
        Me.RadioButtonSQLServerAuthentication.TabIndex = 8
        Me.RadioButtonSQLServerAuthentication.TabStop = True
        Me.RadioButtonSQLServerAuthentication.Text = "SQL Server Authentication"
        Me.RadioButtonSQLServerAuthentication.UseVisualStyleBackColor = True
        '
        'RadioButtonWindowsAuthentication
        '
        Me.RadioButtonWindowsAuthentication.AutoSize = True
        Me.RadioButtonWindowsAuthentication.Location = New System.Drawing.Point(66, 110)
        Me.RadioButtonWindowsAuthentication.Name = "RadioButtonWindowsAuthentication"
        Me.RadioButtonWindowsAuthentication.Size = New System.Drawing.Size(140, 17)
        Me.RadioButtonWindowsAuthentication.TabIndex = 7
        Me.RadioButtonWindowsAuthentication.TabStop = True
        Me.RadioButtonWindowsAuthentication.Text = "Windows Authentication"
        Me.RadioButtonWindowsAuthentication.UseVisualStyleBackColor = True
        '
        'LabelEnterAuthentication
        '
        Me.LabelEnterAuthentication.AutoSize = True
        Me.LabelEnterAuthentication.Location = New System.Drawing.Point(25, 94)
        Me.LabelEnterAuthentication.Name = "LabelEnterAuthentication"
        Me.LabelEnterAuthentication.Size = New System.Drawing.Size(208, 13)
        Me.LabelEnterAuthentication.TabIndex = 6
        Me.LabelEnterAuthentication.Text = "2. Enter Information to log on to the server:"
        '
        'TextBoxServername
        '
        Me.TextBoxServername.Location = New System.Drawing.Point(165, 57)
        Me.TextBoxServername.Name = "TextBoxServername"
        Me.TextBoxServername.Size = New System.Drawing.Size(198, 20)
        Me.TextBoxServername.TabIndex = 4
        '
        'LabelServername
        '
        Me.LabelServername.AutoSize = True
        Me.LabelServername.Location = New System.Drawing.Point(63, 60)
        Me.LabelServername.Name = "LabelServername"
        Me.LabelServername.Size = New System.Drawing.Size(70, 13)
        Me.LabelServername.TabIndex = 2
        Me.LabelServername.Text = "Server name:"
        '
        'LabelEnterServername
        '
        Me.LabelEnterServername.AutoSize = True
        Me.LabelEnterServername.Location = New System.Drawing.Point(25, 37)
        Me.LabelEnterServername.Name = "LabelEnterServername"
        Me.LabelEnterServername.Size = New System.Drawing.Size(108, 13)
        Me.LabelEnterServername.TabIndex = 1
        Me.LabelEnterServername.Text = "1. Enter server name:"
        '
        'LabelSpecify
        '
        Me.LabelSpecify.AutoSize = True
        Me.LabelSpecify.Location = New System.Drawing.Point(10, 14)
        Me.LabelSpecify.Name = "LabelSpecify"
        Me.LabelSpecify.Size = New System.Drawing.Size(161, 13)
        Me.LabelSpecify.TabIndex = 0
        Me.LabelSpecify.Text = "Specify the following to connect:"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Location = New System.Drawing.Point(313, 367)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 57
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Location = New System.Drawing.Point(232, 367)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOK.TabIndex = 1
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'frmConfiq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 402)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Name = "frmConfiq"
        Me.Text = "Configuration"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents LabelDatabasename As System.Windows.Forms.Label
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents LabelFeedback As System.Windows.Forms.Label
    Friend WithEvents ButtonTestConnection As System.Windows.Forms.Button
    Friend WithEvents TextBoxDatabasename As System.Windows.Forms.TextBox
    Friend WithEvents LabelEnterDatabasename As System.Windows.Forms.Label
    Friend WithEvents LabelPassword As System.Windows.Forms.Label
    Friend WithEvents TextBoxPassword As System.Windows.Forms.TextBox
    Friend WithEvents LabelUsername As System.Windows.Forms.Label
    Friend WithEvents TextBoxUsername As System.Windows.Forms.TextBox
    Friend WithEvents RadioButtonSQLServerAuthentication As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonWindowsAuthentication As System.Windows.Forms.RadioButton
    Friend WithEvents LabelEnterAuthentication As System.Windows.Forms.Label
    Friend WithEvents TextBoxServername As System.Windows.Forms.TextBox
    Friend WithEvents LabelServername As System.Windows.Forms.Label
    Friend WithEvents LabelEnterServername As System.Windows.Forms.Label
    Friend WithEvents LabelSpecify As System.Windows.Forms.Label

End Class
