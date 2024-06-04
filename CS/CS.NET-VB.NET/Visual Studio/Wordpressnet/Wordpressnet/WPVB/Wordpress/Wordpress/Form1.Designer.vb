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
        Me.btnPost = New System.Windows.Forms.Button
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.txtPost = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnPost
        '
        Me.btnPost.Location = New System.Drawing.Point(2, 302)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(330, 55)
        Me.btnPost.TabIndex = 3
        Me.btnPost.Text = "Post to Blog"
        Me.btnPost.UseVisualStyleBackColor = True
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(4, 21)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(330, 21)
        Me.txtTitle.TabIndex = 1
        '
        'txtPost
        '
        Me.txtPost.Location = New System.Drawing.Point(2, 65)
        Me.txtPost.Multiline = True
        Me.txtPost.Name = "txtPost"
        Me.txtPost.Size = New System.Drawing.Size(330, 222)
        Me.txtPost.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Post Title :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Post :"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 363)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPost)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.btnPost)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Form1"
        Me.Text = "Post to Wordpress"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPost As System.Windows.Forms.Button
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtPost As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
