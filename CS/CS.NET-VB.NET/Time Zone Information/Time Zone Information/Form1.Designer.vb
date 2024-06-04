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
        Me.YearNumericUpDown = New System.Windows.Forms.NumericUpDown
        Me.TZComboBox = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.ApplyButton = New System.Windows.Forms.Button
        Me.CancelButton1 = New System.Windows.Forms.Button
        Me.CTZComboBox = New System.Windows.Forms.ComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.DisplayRichTextBox = New System.Windows.Forms.RichTextBox
        CType(Me.YearNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'YearNumericUpDown
        '
        Me.YearNumericUpDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.YearNumericUpDown.Location = New System.Drawing.Point(343, 331)
        Me.YearNumericUpDown.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.YearNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.YearNumericUpDown.Name = "YearNumericUpDown"
        Me.YearNumericUpDown.Size = New System.Drawing.Size(57, 20)
        Me.YearNumericUpDown.TabIndex = 6
        Me.YearNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TZComboBox
        '
        Me.TZComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TZComboBox.FormattingEnabled = True
        Me.TZComboBox.Location = New System.Drawing.Point(6, 19)
        Me.TZComboBox.MaxDropDownItems = 30
        Me.TZComboBox.Name = "TZComboBox"
        Me.TZComboBox.Size = New System.Drawing.Size(394, 21)
        Me.TZComboBox.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(253, 333)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Daylight Saving:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TZComboBox)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 95)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(406, 54)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select a Time Zone for Preview"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox2.Controls.Add(Me.CTZComboBox)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(406, 77)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Current System Time Zone"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ApplyButton, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CancelButton1, 0, 0)
        Me.TableLayoutPanel1.Enabled = False
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(238, 46)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(162, 30)
        Me.TableLayoutPanel1.TabIndex = 13
        '
        'ApplyButton
        '
        Me.ApplyButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ApplyButton.Location = New System.Drawing.Point(84, 3)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(75, 23)
        Me.ApplyButton.TabIndex = 9
        Me.ApplyButton.Text = "Apply"
        Me.ApplyButton.UseVisualStyleBackColor = True
        '
        'CancelButton1
        '
        Me.CancelButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CancelButton1.Location = New System.Drawing.Point(3, 3)
        Me.CancelButton1.Name = "CancelButton1"
        Me.CancelButton1.Size = New System.Drawing.Size(75, 23)
        Me.CancelButton1.TabIndex = 10
        Me.CancelButton1.Text = "Cancel"
        Me.CancelButton1.UseVisualStyleBackColor = True
        '
        'CTZComboBox
        '
        Me.CTZComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CTZComboBox.FormattingEnabled = True
        Me.CTZComboBox.Location = New System.Drawing.Point(6, 19)
        Me.CTZComboBox.MaxDropDownItems = 30
        Me.CTZComboBox.Name = "CTZComboBox"
        Me.CTZComboBox.Size = New System.Drawing.Size(394, 21)
        Me.CTZComboBox.TabIndex = 8
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.DisplayRichTextBox)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.YearNumericUpDown)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 155)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(406, 357)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tiem Zone Information:"
        '
        'DisplayRichTextBox
        '
        Me.DisplayRichTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DisplayRichTextBox.BackColor = System.Drawing.SystemColors.Window
        Me.DisplayRichTextBox.Location = New System.Drawing.Point(6, 19)
        Me.DisplayRichTextBox.Name = "DisplayRichTextBox"
        Me.DisplayRichTextBox.ReadOnly = True
        Me.DisplayRichTextBox.Size = New System.Drawing.Size(394, 306)
        Me.DisplayRichTextBox.TabIndex = 12
        Me.DisplayRichTextBox.Text = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 524)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Time Zone Information Demo - By VBDT"
        CType(Me.YearNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents YearNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents TZComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CTZComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DisplayRichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents ApplyButton As System.Windows.Forms.Button
    Friend WithEvents CancelButton1 As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel

End Class
