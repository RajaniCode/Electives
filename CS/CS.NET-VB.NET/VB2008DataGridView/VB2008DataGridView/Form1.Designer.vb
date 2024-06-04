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
        Me.UnboundDataGridView = New System.Windows.Forms.DataGridView
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.BoundTimeTextBox = New System.Windows.Forms.TextBox
        Me.UnboundTimeTextBox = New System.Windows.Forms.TextBox
        Me.RecordCountTextBox = New System.Windows.Forms.TextBox
        CType(Me.UnboundDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UnboundDataGridView
        '
        Me.UnboundDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.UnboundDataGridView.Location = New System.Drawing.Point(39, 45)
        Me.UnboundDataGridView.Name = "UnboundDataGridView"
        Me.UnboundDataGridView.Size = New System.Drawing.Size(748, 220)
        Me.UnboundDataGridView.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(39, 301)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Bound"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(396, 301)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Unbound"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'BoundTimeTextBox
        '
        Me.BoundTimeTextBox.Location = New System.Drawing.Point(143, 304)
        Me.BoundTimeTextBox.Name = "BoundTimeTextBox"
        Me.BoundTimeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.BoundTimeTextBox.TabIndex = 3
        '
        'UnboundTimeTextBox
        '
        Me.UnboundTimeTextBox.Location = New System.Drawing.Point(537, 303)
        Me.UnboundTimeTextBox.Name = "UnboundTimeTextBox"
        Me.UnboundTimeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.UnboundTimeTextBox.TabIndex = 4
        '
        'RecordCountTextBox
        '
        Me.RecordCountTextBox.Location = New System.Drawing.Point(687, 301)
        Me.RecordCountTextBox.Name = "RecordCountTextBox"
        Me.RecordCountTextBox.Size = New System.Drawing.Size(100, 20)
        Me.RecordCountTextBox.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(866, 414)
        Me.Controls.Add(Me.RecordCountTextBox)
        Me.Controls.Add(Me.UnboundTimeTextBox)
        Me.Controls.Add(Me.BoundTimeTextBox)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.UnboundDataGridView)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.UnboundDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UnboundDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents BoundTimeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UnboundTimeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RecordCountTextBox As System.Windows.Forms.TextBox

End Class
