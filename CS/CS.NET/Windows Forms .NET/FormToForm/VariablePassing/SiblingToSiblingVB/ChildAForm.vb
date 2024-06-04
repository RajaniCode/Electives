Public Class ChildAForm
    Inherits System.Windows.Forms.Form

    Public Event ValueUpdated(ByVal sender As Object, _
        ByVal e As ValueUpdatedEventArgs)

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents uxOtherValue As System.Windows.Forms.TextBox
    Friend WithEvents uxOtherValueLabel As System.Windows.Forms.Label
    Friend WithEvents uxMyValue As System.Windows.Forms.TextBox
    Friend WithEvents uxMyValueLabel As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.uxOtherValue = New System.Windows.Forms.TextBox
        Me.uxOtherValueLabel = New System.Windows.Forms.Label
        Me.uxMyValue = New System.Windows.Forms.TextBox
        Me.uxMyValueLabel = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'uxOtherValue
        '
        Me.uxOtherValue.Location = New System.Drawing.Point(88, 40)
        Me.uxOtherValue.Name = "uxOtherValue"
        Me.uxOtherValue.ReadOnly = True
        Me.uxOtherValue.Size = New System.Drawing.Size(192, 20)
        Me.uxOtherValue.TabIndex = 7
        Me.uxOtherValue.Text = ""
        '
        'uxOtherValueLabel
        '
        Me.uxOtherValueLabel.Location = New System.Drawing.Point(8, 40)
        Me.uxOtherValueLabel.Name = "uxOtherValueLabel"
        Me.uxOtherValueLabel.Size = New System.Drawing.Size(72, 23)
        Me.uxOtherValueLabel.TabIndex = 6
        Me.uxOtherValueLabel.Text = "Other Value:"
        '
        'uxMyValue
        '
        Me.uxMyValue.Location = New System.Drawing.Point(88, 8)
        Me.uxMyValue.Name = "uxMyValue"
        Me.uxMyValue.Size = New System.Drawing.Size(192, 20)
        Me.uxMyValue.TabIndex = 5
        Me.uxMyValue.Text = ""
        '
        'uxMyValueLabel
        '
        Me.uxMyValueLabel.Location = New System.Drawing.Point(8, 8)
        Me.uxMyValueLabel.Name = "uxMyValueLabel"
        Me.uxMyValueLabel.Size = New System.Drawing.Size(56, 23)
        Me.uxMyValueLabel.TabIndex = 4
        Me.uxMyValueLabel.Text = "My Value:"
        '
        'ChildAForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 70)
        Me.Controls.Add(Me.uxOtherValue)
        Me.Controls.Add(Me.uxMyValue)
        Me.Controls.Add(Me.uxOtherValueLabel)
        Me.Controls.Add(Me.uxMyValueLabel)
        Me.Name = "ChildAForm"
        Me.Text = "Child 'A' Form"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub uxMyValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uxMyValue.TextChanged
        Dim newValue As String
        newValue = Me.uxMyValue.Text
        Dim valueArgs As ValueUpdatedEventArgs
        valueArgs = New ValueUpdatedEventArgs(newValue)
        RaiseEvent ValueUpdated(Me, valueArgs)
    End Sub

    Public Sub ChildBValueUpdated(ByVal sender As Object, ByVal e As ValueUpdatedEventArgs)
        Me.uxOtherValue.Text = e.NewValue
    End Sub
End Class
